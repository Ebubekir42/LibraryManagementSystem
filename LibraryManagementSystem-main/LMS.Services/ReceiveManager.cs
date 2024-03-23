using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class ReceiveManager : IReceiveService
    {
        private readonly IRepositoryManager _manager;
        public ReceiveManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public Receive GetReceive(int id, bool trackChanges)
        {
            return _manager.Receive.GetReceive(id, trackChanges);
        }

        public IQueryable<Receive> GetReceives(bool trackChanges)
        {
            return _manager.Receive.GetAllReceives(trackChanges);
        }
        public void CreateReceive(Receive receive)
        {
            _manager.Receive.CreateReceive(receive);
            _manager.Save();
        }
        public void ReceiveBook(int receiveId, string perId)
        {
            var receive = _manager.Receive.GetReceive(receiveId, true);
            receive.ApplicationUserId = perId;
            _manager.Save();
        }
    }
}
