using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movienet
{
    public class VM_Locator
    {
        public static VM_MainWindow vm_MW { get; set; }

        public VM_Locator()
        {
            vm_MW = new VM_MainWindow();
        }
    }
}
