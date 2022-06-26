using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderManagement.Models;

namespace TenderManagement.Business.Repository.IRepository
{
    public interface ITenderRepository
    {
        public Task<CreateTenderDTO> Create(CreateTenderDTO objDTO);
        public Task<UpdateTenderDTO> Update(Guid tenderId, UpdateTenderDTO objDTO);
        public Task<int> Delete(Guid id);
        public Task<TenderDTO> Get(Guid id);
        public Task<IEnumerable<TenderDTO>> GetAll();
    }
}
