using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Fee
    {
        public int FeeID { get; set; } // Primary Key
        public int? StudentID { get; set; } // Foreign Key
        public decimal? Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; } // Nullable
    }
}
