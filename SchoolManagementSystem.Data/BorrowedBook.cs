using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class BorrowedBook
    {
        public int BorrowID { get; set; } // Primary Key
        public int? StudentID { get; set; } // Foreign Key
        public int? LibraryID { get; set; } // Foreign Key
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable
    }
}
