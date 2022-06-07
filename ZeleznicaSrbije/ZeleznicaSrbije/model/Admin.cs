using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Admin : User
    {
        public Admin(string user, string pass, int x) : base(user, pass, x)
        {
        }
    }
}
