using Longplay.DataAccess.Repository.IRepository;
using Longplay.Model;

namespace Longplay.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _context;

        public CoverTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
  
        public void Update(CoverType obj)
        {
            _context.CoverTypes.Update(obj);
        }
    }
}
