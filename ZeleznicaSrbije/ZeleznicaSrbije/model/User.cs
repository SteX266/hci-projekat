using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public abstract class User
    {

        protected int id { get; set; }
        protected string username { get; set; }
        protected string password { get; set; }

        public User(string user, string pass , int x)
            {
                username = user;
                password = pass;
                id = x;
            }

        }
    }
