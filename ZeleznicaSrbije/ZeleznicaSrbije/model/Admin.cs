using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Admin : User
    {
        public Admin( int x,string user, string pass) : base(user, pass, x)
        {
        }
    }
}
