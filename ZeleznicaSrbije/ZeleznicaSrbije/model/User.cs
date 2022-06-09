using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public abstract class User
    {

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User(string user, string pass , int x)
            {
                username = user;
                password = pass;
                id = x;
            }

        }
    }
