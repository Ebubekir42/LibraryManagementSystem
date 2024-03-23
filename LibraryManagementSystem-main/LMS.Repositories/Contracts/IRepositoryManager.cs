namespace LMS.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        ICategoryRepository Category { get; }
        IBookAuthorRepository BookAuthor { get; }
        ILoanRepository Loan { get; }
        IMediaTypeRepository MediaType { get; }
        IContentTypeRepository ContentType { get; }
        ICarrierTypeRepository CarrierType { get; }
        IFormatRepository Format { get; }
        ILanguageRepository Language { get; }
        IFineRepository Fine { get; }
        IOrderRepository Order { get; }
        IProvinceRepository Province { get; }
        IDistrictRepository District { get; }
        INonOrderRepository NonOrder { get; }
        IBookingOfficeRepository BookOffice { get; }
        IReceiveRepository Receive { get; }
        void Save();
    }
}
