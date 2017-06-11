using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quilix.RegisterTasks.Dal
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Middle_name { get; set; }
        [Required]
        public string Last_name { get; set; }



    }
}
