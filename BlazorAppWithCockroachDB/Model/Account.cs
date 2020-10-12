using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppWithCockroachDB.Model
{
    public class Account
    {       
        public int id { get; set; }

        public int balance { get; set; }

        public string name { get; set; }
    }
}
