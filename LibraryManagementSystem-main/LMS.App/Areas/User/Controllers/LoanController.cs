using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.App.Models;
using LMS.Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LMS.App.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class LoanController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoanController(IServiceManager manager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        private void ControlTheLoan()
        {
            _manager.LoanService.ControlTheLoans();
        }
        public async Task<IActionResult> Index()
        {
            ControlTheLoan();
            ApplicationUser user = null;
            var currentUser = HttpContext.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = await _userManager.FindByIdAsync(userId);
            }
            var loans = _manager.LoanService.GetAllLoans(false).Where(l => l.ApplicationUserId.Equals(user.Id));
            List<LoanListViewModel> loanList = new List<LoanListViewModel>();
            foreach (var loan in loans)
            {
                var book = _manager.BookService.GetOneBook(loan.BookId, false);
                String? perId = null;
                String? orderNo = "";
                if (!loan.IsOrder)
                {
                    
                    var nonOrders = _manager.NonOrderService.GetAllNonOrders(false);
                    foreach(var nonOrder in nonOrders)
                    {
                        if (!nonOrder.IsDeliver && nonOrder.LoanId.Equals(loan.LoanId))
                        {
                            perId = nonOrder.ApplicationUserId;
                            break;
                        }
                    }
                }
                else
                {
                    var orders = _manager.OrderService.GetAllOrders(false);
                    foreach(var order in orders)
                    {
                        if(order.LoanId.Equals(loan.LoanId) && !order.IsDeliver)
                        {
                            orderNo = order.OrderNo;
                            break;
                        }
                    }
                }
                loanList.Add(new LoanListViewModel()
                {
                    Book = book,
                    Loan = loan,
                    PerId = perId,
                    OrderNo = orderNo
                });
            }
            return View(loanList);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm(Name = "Id")] int id)
        {
            var book = _manager.BookService.GetOneBook(id, false);
            ApplicationUser user = null;
            var currentUser = HttpContext.User;
            if (currentUser.Identity.IsAuthenticated)
            {
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = await _userManager.FindByIdAsync(userId);
            }
            var loans = _manager.LoanService.GetAllLoans(false).Where(l => l.ApplicationUserId.Equals(user.Id));
            var count = loans.Where(l => l.ReturnedDate == null).Count();
            if(count  < 3)
            {
                var fine = _manager.FineService.GetAllFines(false).Where(f => f.ApplicationUserId.Equals(user.Id)).FirstOrDefault();
                if(fine.Quantity == 0)
                {
                    _manager.LoanService.CreateLoan(user, book);
                    return RedirectToAction("Index", "Loan");
                }
                else
                {
                    TempData["info"] = "Kitap almak için lütfen borçlarınızı ödemelisiniz.";
                    return RedirectToAction("Index", "Book", new { area = "" });
                }
            }
            TempData["info"] = "En fazla 3 kitap aldınız. O yüzden kitap alamazsınız.";
            return RedirectToAction("Index", "Book", new { area = "" });
            
        }
        public async Task<IActionResult> Return([FromForm] int id)
        {
            _manager.LoanService.ReturnTheBook(id);
            return RedirectToAction("Index", "Loan");
        }
        [HttpGet]
        public IActionResult Den(ApplicationUser user, int status,Book book)
        {
            return View();
        }
    }
}
