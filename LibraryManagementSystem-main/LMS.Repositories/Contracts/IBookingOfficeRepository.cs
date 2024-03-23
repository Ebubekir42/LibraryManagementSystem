using LMS.Entities.Models;
namespace LMS.Repositories.Contracts
{
    public interface IBookingOfficeRepository : IRepostioryBase<BookingOffice>
    {
        BookingOffice GetBookingOfficeById(int id, bool trackChanges);
        BookingOffice GetBookingOfficeByPersonelId(string personelId, bool trackChanges);
        IQueryable<BookingOffice> GetAllBookingOffices(bool trackChanges);
        void CreateBookingOffice(BookingOffice bookingOffice);
    }
}
