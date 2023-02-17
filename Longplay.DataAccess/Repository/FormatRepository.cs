using Longplay.DataAccess.Repository.IRepository;
using Longplay.Model;

namespace Longplay.DataAccess.Repository
{
    public class FormatRepository : Repository<Format>, IFormatRepository
    {
        private ApplicationDbContext _context;

        public FormatRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
  
        public void Update(Format obj)
        {
            _context.Formats.Update(obj);
        }
    }
}
