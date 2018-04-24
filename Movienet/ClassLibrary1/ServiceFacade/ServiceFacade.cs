using ClassLibrary1.Factory;
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
            cDao = AbstractDaoFactory.getFactory().getCommentDao();
            fDao = AbstractDaoFactory.getFactory().getFilmDao();
            uDao = AbstractDaoFactory.getFactory().GetUserDao();
        }

        public ICommentDao GetCommentDao()
        {
            return cDao;
        }

        public IFilmDao GetFilmDao()
        {
            return fDao;
        }

        public IUserDao GetUserDao()
        {
            return uDao;
        }
    }
}
