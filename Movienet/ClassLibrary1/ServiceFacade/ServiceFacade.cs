using ClassLibrary1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ServiceFacade
{
    class ServiceFacade : IServiceFacade
    {

        private IUserDao uDao    = null;
        private IFilmDao fDao    = null;
        private ICommentDao cDao = null;

        public ServiceFacade() {

        };
        public ICommentDao GetCommentDao()
        {
            throw new NotImplementedException();
        }

        public IFilmDao GetFilmDao()
        {
            throw new NotImplementedException();
        }

        public IUserDao GetUserDao()
        {
            throw new NotImplementedException();
        }
    }
}
