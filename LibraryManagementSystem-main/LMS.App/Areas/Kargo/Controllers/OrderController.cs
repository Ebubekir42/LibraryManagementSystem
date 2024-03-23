using LMS.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.App.Models;

namespace LMS.App.Areas.Kargo.Controllers
{
    [Area("Kargo")]
    [Authorize(Roles = "Kargo")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var orders = _manager.OrderService.GetAllOrders(false);
            List<OrderInfo> ordersInfo = new List<OrderInfo>();
            var perName = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perName);
            var perId = per.Id;
            orders = orders.Where(x => x.ApplicationUserId != null);
            orders = orders.Where(x => x.ApplicationUserId.Equals(perId));
            foreach(var order in orders)
            {
                var orderNo = order.OrderNo;
                var loan = _manager.LoanService.GetLoan(order.LoanId, false);
                var user = await _manager.ApplicationUserService.GetOneUserByUserId(loan.ApplicationUserId);
                var book = _manager.BookService.GetOneBook(loan.BookId, false);
                var district = _manager.DistrictService.GetDistrict(order.DistrictId, false);
                var province = _manager.ProvinceService.GetProvince(district.ProvinceId, false);
                var orderinfo = new OrderInfo()
                {
                    Id = order.OrderId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = order.Address,
                    Province = province.Name,
                    District = district.DistrictName,
                    Book = book,
                    OrderNo = orderNo
                };
                if(order.ApplicationUserId is not null)
                    orderinfo.KuryeId = order.ApplicationUserId;
                ordersInfo.Add(orderinfo);
            }
            return View(new OrderList() {CurrentKuryeId = perId, OrderInfos = ordersInfo });
        }
        public async Task<IActionResult> Buy()
        {
            var orders = _manager.OrderService.GetAllOrders(false);
            List<OrderInfo> ordersInfo = new List<OrderInfo>();
            var perName = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perName);
            var perId = per.Id;
            foreach (var order in orders)
            {
                var orderNo = order.OrderNo;
                var loan = _manager.LoanService.GetLoan(order.LoanId, false);
                var user = await _manager.ApplicationUserService.GetOneUserByUserId(loan.ApplicationUserId);
                var book = _manager.BookService.GetOneBook(loan.BookId, false);
                var district = _manager.DistrictService.GetDistrict(order.DistrictId, false);
                var province = _manager.ProvinceService.GetProvince(district.ProvinceId, false);
                var orderinfo = new OrderInfo()
                {
                    Id = order.OrderId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = order.Address,
                    Province = province.Name,
                    District = district.DistrictName,
                    Book = book,
                    OrderNo = orderNo
                };
                if (order.ApplicationUserId is not null)
                    orderinfo.KuryeId = order.ApplicationUserId;
                ordersInfo.Add(orderinfo);
            }
            return View(new OrderList() { CurrentKuryeId = perId, OrderInfos = ordersInfo });
        }
        [HttpPost]
        public async Task<IActionResult> Buy([FromForm]int buyId)
        {
            var kuryeName = User.Identity.Name;
            var kurye = await _manager.ApplicationUserService.GetOneUserByUserName(kuryeName);
            _manager.OrderService.BuyOrder(buyId, kurye.Id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Deliver([FromForm]int deliverId)
        {
            _manager.OrderService.DeliverOrder(deliverId);
            return RedirectToAction("Index");
        }
    }
}
