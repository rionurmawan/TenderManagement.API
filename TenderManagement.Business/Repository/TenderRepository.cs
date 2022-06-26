using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TenderManagement.Business.Repository.IRepository;
using TenderManagement.DataAccess;
using TenderManagement.DataAccess.Data;
using TenderManagement.Models;

namespace TenderManagement.Business.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TenderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CreateTenderDTO> Create(CreateTenderDTO objDTO)
        {
            var obj = _mapper.Map<CreateTenderDTO, Tender>(objDTO);

            var addedObj = _db.Tenders.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Tender, CreateTenderDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(Guid id)
        {
            //var obj = await _db.Tenders.FirstOrDefaultAsync(u => u.Id == id);
            //if (obj != null)
            //if (obj != null)
            //{
            //    _db.Tenders.Remove(obj);
            //    return await _db.SaveChangesAsync();
            //}

            //return 0;

            _db.Database.ExecuteSqlRaw("EXEC DeleteTenders @p0", parameters: new[] { id.ToString() });
            return 1;
        }

        public async Task<TenderDTO> Get(Guid id)
        {
            var obj = await _db.Tenders.Include("User").FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Tender, TenderDTO>(obj);
            }
            return new TenderDTO();
        }

        public async Task<IEnumerable<TenderDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Tender>, IEnumerable<TenderDTO>>(_db.Tenders.Include("User"));
        }

        public async Task<UpdateTenderDTO> Update(Guid tenderId, UpdateTenderDTO objDTO)
        {
            var objFromDb = await _db.Tenders.FirstOrDefaultAsync(u => u.Id == tenderId);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                objFromDb.ReferenceNumber = objDTO.ReferenceNumber;
                objFromDb.Description = objDTO.Description;
                objFromDb.ReleaseDate = objDTO.ReleaseDate;
                objFromDb.ClosingDate = objDTO.ClosingDate;
                
                _db.Tenders.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Tender, UpdateTenderDTO>(objFromDb);
            }

            return objDTO;
        }
    }
}
