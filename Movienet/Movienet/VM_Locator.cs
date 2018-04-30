using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movienet
{
    public class VM_Locator
    {
        public static VM_AddUser VM_AddUser { get; } = new VM_AddUser();
        public static VM_DisplayUsers VM_DisplayUsers { get; } = new VM_DisplayUsers();
    }
}
