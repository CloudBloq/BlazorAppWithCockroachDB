using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppWithCockroachDB.Model
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Balance is required")]
        [Range(minimum: 1, 99999999, ErrorMessage = "Minimum allowed balance is $1")]
        public int balance { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
    }
}
