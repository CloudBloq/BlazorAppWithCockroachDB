using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CockroachDbLib.Models
{
    public class Account
    {
        [Key]        
        public int id { get; set; }

        public int balance { get; set; }

        public string name { get; set; }

    }
}
