using LMS.Entities.Models;

namespace LMS.Services.Contracts
{
    public interface IReceiveService
    {
        Receive GetReceive(int id,bool trackChanges);
        IQueryable<Receive> GetReceives(bool trackChanges);
        void CreateReceive(Receive receive);
        void ReceiveBook(int receiveId, string perId);

    }
}
