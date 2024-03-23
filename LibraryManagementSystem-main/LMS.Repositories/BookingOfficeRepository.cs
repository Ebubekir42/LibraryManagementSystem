using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class BookingOfficeRepository : RepositoryBase<BookingOffice>, IBookingOfficeRepository
    {
        public BookingOfficeRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<BookingOffice> GetAllBookingOffices(bool trackChanges) => FindAll(trackChanges);

        public BookingOffice GetBookingOfficeById(int id, bool trackChanges)
        {
            return FindByCondition(b => b.BookingOfficeId.Equals(id),trackChanges);
        }
        public BookingOffice GetBookingOfficeByPersonelId(string personelId, bool trackChanges)
        {
            return FindByCondition(b => b.ApplicationUserId.Equals(personelId), trackChanges);
        }

        public void CreateBookingOffice(BookingOffice bookingOffice) => Create(bookingOffice);
    }
}
