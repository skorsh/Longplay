using Longplay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longplay.DataAccess.Repository.IRepository
{
    public interface IFormatRepository : IRepository<Format>
    {
        void Update(Format obj);
    }
}
