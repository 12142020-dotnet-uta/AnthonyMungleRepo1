using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{ 
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        public BusinessLogicClass(Repository repository)
        {
            _repository = repository;
        }
    }
}
