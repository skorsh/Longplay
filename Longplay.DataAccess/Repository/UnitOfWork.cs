using Longplay.DataAccess.Repository.IRepository;

namespace Longplay.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Format = new FormatRepository(_context);
        }

        public ICategoryRepository Category { get; private set; }
        public IFormatRepository Format { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
