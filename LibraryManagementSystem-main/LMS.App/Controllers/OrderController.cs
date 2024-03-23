using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS.Services.Contracts;
using LMS.Entities.Dtos;
using LMS.App.Models;
using LMS.Entities.Models;

namespace LMS.App.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> Create(OrderListViewModel o)
        {
            var userId = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userId);
            var loans = _manager.LoanService.GetAllLoans(false).Where(l => l.ApplicationUserId.Equals(user.Id));
            var count = loans.Where(l => l.ReturnedDate == null).Count();
            if(count < 3)
            {
                var fine = _manager.FineService.GetAllFines(false).Where(f => f.ApplicationUserId.Equals(user.Id)).FirstOrDefault();
                if(fine.Quantity == 0)
                {
                    o.FirstName = user.FirstName;
                    o.LastName = user.LastName;
                    o.PhoneNumber = user.PhoneNumber;
                    o.Email = user.Email;
                    ViewBag.Provinces = GetProvincesSelectList(o.ProvinceId);
                    ViewBag.Districts = GetDistrictsSelectList(o.ProvinceId);

                    var book = _manager.BookService.GetOneBook(o.BookId, false);
                    o.Book = book;
                    return View(o);
                }
                else
                {
                    TempData["info"] = "Kitap almak için lütfen borçlarınızı ödemelisiniz." ;
                    return RedirectToAction("Index", "Book", new { area = "" });
                }
            }
            TempData["info"] = "En fazla 3 kitap aldınız. O yüzden kitap alamazsınız.";
            return RedirectToAction("Index", "Book", new { area = "" });

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderDtoForInsertion o)
        {
            var userId = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userId);
            bool isOrder = o.isOrder.Equals(1) ? false : true;

            if (o.isOrder.Equals(0))
            {
                TempData["info"] = "Lütfen kutucuğu işaretleyin";
                return View();
            }
            else if (!isOrder) // Personel
            {
                Loan loan = new Loan() { BookId = o.BookId, IsOrder = isOrder,ApplicationUserId = user.Id };
                _manager.LoanService.CreateLoan(loan);
                Receive receive = new Receive() { LoanId = loan.LoanId };
                _manager.ReceiveService.CreateReceive(receive);
                //if(_manager.NonOrderService.GetAllNonOrders(false).Count().Equals(0))
                //{
                //    var personel = _manager.BookingOfficeService.GetAllBookingOffices(false).ToList().FirstOrDefault();
                //    //NonOrder nonOrder = new NonOrder() { LoanId = loan.LoanId, ApplicationUserId = personel.ApplicationUserId };
                //    NonOrder nonOrder = new NonOrder() { LoanId = loan.LoanId};
                //    _manager.NonOrderService.CreateNonOrder(nonOrder);
                //}
                //else
                //{
                //    int count_ = _manager.NonOrderService.GetAllNonOrders(false).Count();
                //    String? personelId = _manager.NonOrderService.GetAllNonOrders(false).ToList().LastOrDefault().ApplicationUserId;
                //    var personel = _manager.BookingOfficeService.GetBookingOfficeByPersonelId(personelId, false);
                //    int count = _manager.BookingOfficeService.GetAllBookingOffices(false).Count();
                //    if(count < (personel.BookingOfficeId + 1))
                //    {
                //        personelId = _manager.BookingOfficeService.GetBookingOfficeById(1,false).ApplicationUserId;
                //    }
                //    else
                //    {
                //        personelId = _manager.BookingOfficeService.GetBookingOfficeById(personel.BookingOfficeId + 1,false).ApplicationUserId;
                //    }
                //    //NonOrder nonOrder = new NonOrder() { LoanId = loan.LoanId, ApplicationUserId = personelId };
                //    NonOrder nonOrder = new NonOrder() { LoanId = loan.LoanId};
                //    _manager.NonOrderService.CreateNonOrder(nonOrder);
                //}
                NonOrder nonOrder = new NonOrder() { LoanId = loan.LoanId };
                _manager.NonOrderService.CreateNonOrder(nonOrder);
                return RedirectToAction("Index", "Loan", new {area = "User"});
            }
            else  // Kargo
            {
                Loan loan = new Loan() { BookId = o.BookId, IsOrder = isOrder, ApplicationUserId = user.Id };
                _manager.LoanService.CreateLoan(loan);
                Receive receive = new Receive() { LoanId = loan.LoanId };
                _manager.ReceiveService.CreateReceive(receive);
                string text = "";
                for(int i = 0; i < 10; i++)
                {
                    text += new Random().Next(minValue: 1, maxValue: 10).ToString();
                }

                Order order = new Order() { LoanId = loan.LoanId, Address = o.Address,DistrictId = o.DistrictId, OrderNo = text };
                _manager.OrderService.CreateOrder(order);
                return RedirectToAction("Index", "Loan", new { area = "User" });
            }


        }
        private SelectList GetProvincesSelectList(int id = 1)
        {
            return new SelectList(
                _manager.ProvinceService.GetAllProvinces(false).OrderBy(item => item.Name),
                "ProvinceId",
                "Name",id);
        }
        private SelectList GetDistrictsSelectList(int id = 1)
        {
            return new SelectList(
                _manager.DistrictService.GetAllDistricts(false).Where(d => d.ProvinceId.Equals(id)),
                "DistrictId",
                "DistrictName");
        }
    }
}
