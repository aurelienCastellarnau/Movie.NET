using ClassLibrary1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Factory
{
    class ServiceFacadeFactory
    {
        IServiceFacade GetServiceFacade() {
            IServiceFacade serviceFacade = null;

            serviceFacade = new ServiceFacade();
        };
    }
}
