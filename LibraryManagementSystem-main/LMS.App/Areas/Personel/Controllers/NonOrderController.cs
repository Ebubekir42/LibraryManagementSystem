using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.App.Models;
namespace LMS.App.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class NonOrderController : Controller
    {
        private readonly IServiceManager _manager;
        public NonOrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var perName = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perName);
            var perId = per.Id;
            var nonOrders = _manager.NonOrderService.GetAllNonOrders(false);
            List<NonOrderInfo> nonOrderInfos = new List<NonOrderInfo>();
            foreach(var nonOrder in nonOrders)
            {
                var loan = _manager.LoanService.GetLoan(nonOrder.LoanId, false);
                //if(loan.ReturnedDate is not null)
                //{
                //    if (!loan.ReturnedDate.Equals("30 gün içinde iade etmediniz."))
                //    {
                //        var user = await _manager.ApplicationUserService.GetOneUserByUserId(loan.ApplicationUserId);
                //        var book = _manager.BookService.GetOneBook(loan.BookId, false);
                //        var nonOrderInfo = new NonOrderInfo()
                //        {
                //            Id = nonOrder.NonOrderId,
                //            FirstName = user.FirstName,
                //            LastName = user.LastName,
                //            PhoneNumber = user.PhoneNumber,
                //            Email = user.Email,
                //            Book = book,
                //            PersonelId = nonOrder.ApplicationUserId
                //        };
                //        nonOrderInfos.Add(nonOrderInfo);
                //    }
                //}
                //else
                //{
                //    var user = await _manager.ApplicationUserService.GetOneUserByUserId(loan.ApplicationUserId);
                //    var book = _manager.BookService.GetOneBook(loan.BookId, false);
                //    var nonOrderInfo = new NonOrderInfo()
                //    {
                //        Id = nonOrder.NonOrderId,
                //        FirstName = user.FirstName,
                //        LastName = user.LastName,
                //        PhoneNumber = user.PhoneNumber,
                //        Email = user.Email,
                //        Book = book,
                //        PersonelId = nonOrder.ApplicationUserId
                //    };
                //    nonOrderInfos.Add(nonOrderInfo);
                //}
                var user = await _manager.ApplicationUserService.GetOneUserByUserId(loan.ApplicationUserId);
                var book = _manager.BookService.GetOneBook(loan.BookId, false);
                var nonOrderInfo = new NonOrderInfo()
                {
                    Id = nonOrder.NonOrderId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Book = book,
                    PersonelId = nonOrder.ApplicationUserId
                };
                nonOrderInfos.Add(nonOrderInfo);


            }
            return View(new NonOrderList() { CurrentPersonelId = perId, nonOrderInfos = nonOrderInfos});
        }
        [HttpPost]
        public async Task<IActionResult> Deliver(int orderId)
        {
            var perId = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perId);
            _manager.NonOrderService.DeliverOrder(orderId,per);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Receive()
        {
            var loans = _manager.LoanService.GetAllLoans(false).Where(l => l.LoanDate is not null).ToList();
            var receives = _manager.ReceiveService.GetReceives(false).ToList();
            List<ReceiveLoanBook> receiveLoans= new List<ReceiveLoanBook>();
            for(int i = 0; i < loans.Count; i++)
            {
                if(loans[i].ReturnedDate is not null)
                {
                    if(!loans[i].ReturnedDate.Equals("30 gün içinde iade etmediniz."))
                    {
                        var user = await _manager.ApplicationUserService.GetOneUserByUserId(loans[i].ApplicationUserId);
                        var book = _manager.BookService.GetOneBook(loans[i].BookId, false);
                        var receiveLoan = new ReceiveLoanBook()
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            LoanId = loans[i].LoanId,
                            ReceiveId = receives[i].ReceiveId,
                            Book = book
                        };
                        if (receives[i].ApplicationUserId is not null)
                            receiveLoan.PersonelId = receives[i].ApplicationUserId;
                        receiveLoans.Add(receiveLoan);
                    }
                }
                else
                {
                    var user = await _manager.ApplicationUserService.GetOneUserByUserId(loans[i].ApplicationUserId);
                    var book = _manager.BookService.GetOneBook(loans[i].BookId, false);
                    var receiveLoan = new ReceiveLoanBook()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        LoanId = loans[i].LoanId,
                        ReceiveId = receives[i].ReceiveId,
                        Book = book
                    };
                    if (receives[i].ApplicationUserId is not null)
                        receiveLoan.PersonelId = receives[i].ApplicationUserId;
                    receiveLoans.Add(receiveLoan);
                }

                
            }
            var perId = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perId);

            return View(new ReceiveInfo() { receiveLoans = receiveLoans, CurrentPersonelId = per.Id });
        }
        [HttpPost]
        public async Task<IActionResult> Receive(int receiveId, int loanId)
        {
            var perName = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perName);
            _manager.ReceiveService.ReceiveBook(receiveId, per.Id);
            _manager.LoanService.ReturnTheBook(loanId);

            return RedirectToAction("Receive");
        }
        [HttpPost]
        public async Task<IActionResult> Buy(int orderId)
        {
            var perId = User.Identity.Name;
            var per = await _manager.ApplicationUserService.GetOneUserByUserName(perId);
            _manager.NonOrderService.BuyOrder(orderId, per);
            return RedirectToAction("Index");
        }
    }
}
