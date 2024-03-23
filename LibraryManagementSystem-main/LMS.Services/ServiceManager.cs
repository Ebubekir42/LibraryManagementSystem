using LMS.Services.Contracts;

namespace LMS.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IBookAuthorService _bookAuthorService;
        private readonly ILoanService _loanService;
        private readonly ICarrierTypeService _carrierTypeService;
        private readonly IContentTypeService _contentTypeService;
        private readonly IMediaTypeService _mediaTypeService;
        private readonly ILanguageService _languageService;
        private readonly IFormatService _formatService;
        private readonly IFineService _fineService;
        private readonly IOrderService _orderService;
        private readonly IProvinceService _provinceService;
        private readonly IDistrictService _districtService;
        private readonly INonOrderService _nonOrderService;
        private readonly IBookingOfficeService _bookingOfficeService;
        private readonly IReceiveService _receiveService;
        public ServiceManager(IBookService bookService, IAuthorService authorService,
                            ICategoryService categoryService, IApplicationUserService applicationUserService,
                            IBookAuthorService bookAuthorService, ILoanService loanService,
                            ICarrierTypeService carrierTypeService, IContentTypeService contentTypeService,
                            IMediaTypeService mediaTypeService, IFormatService formatService, ILanguageService languageService,
                            IFineService fineService, IOrderService orderService, IProvinceService provinceService, IDistrictService districtService,
                            INonOrderService nonOrderService, IBookingOfficeService bookingOfficeService, IReceiveService receiveService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _applicationUserService = applicationUserService;
            _bookAuthorService = bookAuthorService;
            _loanService = loanService;
            _carrierTypeService = carrierTypeService;
            _contentTypeService = contentTypeService;
            _mediaTypeService = mediaTypeService;
            _languageService = languageService;
            _formatService = formatService;
            _fineService = fineService;
            _orderService = orderService;
            _provinceService = provinceService;
            _districtService = districtService;
            _nonOrderService = nonOrderService;
            _bookingOfficeService = bookingOfficeService;
            _receiveService = receiveService;
        }
        public IBookService BookService => _bookService;

        public ICategoryService CategoryService => _categoryService;

        public IAuthorService AuthorService => _authorService;

        public IApplicationUserService ApplicationUserService => _applicationUserService;

        public IBookAuthorService BookAuthorService => _bookAuthorService;

        public ILoanService LoanService => _loanService;

        public IFormatService FormatService => _formatService;

        public ILanguageService LanguageService => _languageService;

        public IMediaTypeService MediaTypeService => _mediaTypeService;

        public IContentTypeService ContentTypeService => _contentTypeService;

        public ICarrierTypeService CarrierTypeService => _carrierTypeService;

        public IFineService FineService => _fineService;

        public IOrderService OrderService => _orderService;

        public IProvinceService ProvinceService => _provinceService;

        public IDistrictService DistrictService => _districtService;

        public INonOrderService NonOrderService => _nonOrderService;

        public IBookingOfficeService BookingOfficeService => _bookingOfficeService;

        public IReceiveService ReceiveService => _receiveService;
    }
}
