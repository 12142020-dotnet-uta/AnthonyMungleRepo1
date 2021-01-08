using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository
    {

        private ProjectDbContext _dbcontext;
        public Repository(ProjectDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

    }
}
