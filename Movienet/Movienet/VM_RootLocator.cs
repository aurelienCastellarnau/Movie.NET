using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movienet
{
    public class VM_RootLocator
    {
        public static VM_RootFrame VM_RootFrame { get; set; }
        public VM_RootLocator()
        {
            VM_RootFrame = new VM_RootFrame();
        }
    }
}
