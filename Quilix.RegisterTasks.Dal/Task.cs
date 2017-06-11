using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Quilix.RegisterTasks.Dal.Anotation;

namespace Quilix.RegisterTasks.Dal
{
    public class Task
    {

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong format")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Start_date { get; set; }
        [Required]

        [ValdDate(ErrorMessage = "Last Date can not be less than Start date.")]

        [DataType(DataType.DateTime, ErrorMessage = "Wrong format")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End_Date { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Employee_Id { get; set; }


    }


    public class TaskGetAll
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong format")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Start_date { get; set; }

        [Required]
        [ValdDate(ErrorMessage = "Last Date can not be less than Start date.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong format")]
        public DateTime End_Date { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
