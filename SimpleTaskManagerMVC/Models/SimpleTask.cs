using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManagerMVC.Models
{
    public class SimpleTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string DueDateString => DueDate.ToString("dd-MMM-yyyy");
        public bool Completed { get; set; }
        public string CompletedString => Completed == true ? "Yes" : "No";
    }
}
