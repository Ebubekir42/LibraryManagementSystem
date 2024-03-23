using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IBookingOfficeService
    {
        BookingOffice GetBookingOfficeById(int id,bool trackChanges);
        BookingOffice GetBookingOfficeByPersonelId(string personelId, bool trackChanges);
        IQueryable<BookingOffice> GetAllBookingOffices(bool trackChanges);
        void CreateBookingOffice(BookingOffice bookingOffice);
    }
}
