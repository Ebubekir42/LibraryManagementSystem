

namespace LMS.Services.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        ICategoryService CategoryService { get; }
        IAuthorService AuthorService { get; }
        IApplicationUserService ApplicationUserService { get; }
        IBookAuthorService BookAuthorService { get; }
        ILoanService LoanService { get; }
        IFormatService FormatService { get; }
        ILanguageService LanguageService { get; }
        IMediaTypeService MediaTypeService { get; }
        IContentTypeService ContentTypeService { get; }
        ICarrierTypeService CarrierTypeService { get; }
        IFineService FineService { get; }
        IOrderService OrderService { get; }
        IProvinceService ProvinceService { get; }
        IDistrictService DistrictService { get; }
        INonOrderService NonOrderService { get; }
        IBookingOfficeService BookingOfficeService { get; }
        IReceiveService ReceiveService { get; }
    }
}
