using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Models;

namespace LMS.Services
{
    public class BookingOfficeManager : IBookingOfficeService
    {
        private readonly IRepositoryManager _manager;
        public BookingOfficeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IQueryable<BookingOffice> GetAllBookingOffices(bool trackChanges)
        {
            return _manager.BookOffice.GetAllBookingOffices(trackChanges);
        }

        public BookingOffice GetBookingOfficeById(int id, bool trackChanges)
        {
            return _manager.BookOffice.GetBookingOfficeById(id, trackChanges);
        }
        public BookingOffice GetBookingOfficeByPersonelId(string personelId,bool trackChanges)
        {
            return _manager.BookOffice.GetBookingOfficeByPersonelId(personelId,trackChanges);
        }
        public void CreateBookingOffice(BookingOffice bookingOffice)
        {
            _manager.BookOffice.CreateBookingOffice(bookingOffice);
            _manager.Save();
        }

    }
}
