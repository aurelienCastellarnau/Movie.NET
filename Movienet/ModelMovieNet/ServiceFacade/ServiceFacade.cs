using ModelMovieNet.Factory;
using ModelMovieNet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMovieNet.ServiceFacade
{
    class ServiceFacade : IServiceFacade
    {

        private IUserDao uDao    = null;
        private IMovieDao fDao    = null;
        private ICommentDao cDao = null;

        public ServiceFacade() {
            cDao = AbstractDaoFactory.getFactory().getCommentDao();
            fDao = AbstractDaoFactory.getFactory().getMovieDao();
            uDao = AbstractDaoFactory.getFactory().GetUserDao();
        }

        public ICommentDao GetCommentDao()
        {
            return cDao;
        }

        public IMovieDao GetFilmDao()
        {
            return fDao;
        }

        public IUserDao GetUserDao()
        {
            return uDao;
        }
    }
}
