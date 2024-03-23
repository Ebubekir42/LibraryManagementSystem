using LMS.Repositories.Contracts;
using LMS.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ICarrierTypeRepository _carrierTypeRepository;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;
        private readonly IFormatRepository _formatRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IFineRepository _fineRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly INonOrderRepository _nonOrderRepository;
        private readonly IBookingOfficeRepository _bookOfficeRepository;
        private readonly IReceiveRepository _receiveRepository;
        public RepositoryManager(RepositoryContext context, IBookRepository bookRepository,
            IAuthorRepository authorRepository, ICategoryRepository categoryRepository,
            IBookAuthorRepository bookAuthorRepository, ILoanRepository loanRepository,
            ILanguageRepository languageRepository, IFormatRepository formatRepository,
            ICarrierTypeRepository carrierTypeRepository, IMediaTypeRepository mediaTypeRepository,
            IContentTypeRepository contentTypeRepository, IFineRepository fineRepository,
            IOrderRepository orderRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository,
            IBookingOfficeRepository bookingOfficeRepository, INonOrderRepository nonOrderRepository, IReceiveRepository receiveRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _loanRepository = loanRepository;
            _languageRepository = languageRepository;
            _formatRepository = formatRepository;
            _carrierTypeRepository = carrierTypeRepository;
            _mediaTypeRepository = mediaTypeRepository;
            _contentTypeRepository = contentTypeRepository;
            _fineRepository = fineRepository;
            _orderRepository = orderRepository;
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _nonOrderRepository = nonOrderRepository;
            _bookOfficeRepository = bookingOfficeRepository;
            _receiveRepository = receiveRepository;
        }
        public IBookRepository Book => _bookRepository;
        public IAuthorRepository Author => _authorRepository;
        public ICategoryRepository Category => _categoryRepository;
        public IBookAuthorRepository BookAuthor => _bookAuthorRepository;
        public ILoanRepository Loan => _loanRepository;

        public IMediaTypeRepository MediaType => _mediaTypeRepository;

        public IContentTypeRepository ContentType => _contentTypeRepository;

        public ICarrierTypeRepository CarrierType => _carrierTypeRepository;

        public IFormatRepository Format => _formatRepository;

        public ILanguageRepository Language => _languageRepository;

        public IFineRepository Fine => _fineRepository;

        public IOrderRepository Order => _orderRepository;

        public IProvinceRepository Province => _provinceRepository;

        public IDistrictRepository District => _districtRepository;

        public INonOrderRepository NonOrder => _nonOrderRepository;

        public IBookingOfficeRepository BookOffice => _bookOfficeRepository;

        public IReceiveRepository Receive => _receiveRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
