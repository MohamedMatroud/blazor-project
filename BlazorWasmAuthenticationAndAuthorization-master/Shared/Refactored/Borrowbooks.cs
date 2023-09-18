using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmAuthenticationAndAuthorization.Shared.Refactored
{
    public  class Borrowbooks
    {
        public int BorrowbookID { get; set; }

        public int? BookID { get; set; } 
        public string BookName { get; set; } 

        public string Borrowername { get; set; } 
        public string NationalID { get; set; } 

        //[Required]
        public DateTime? borrowDate { get; set; } 
        //[Required]

        public DateTime? Returndate { get; set; }

        public string borrowDatestring { get; set; }
        //[Required]

        public string Returndatestring { get; set; }
        public long? Price { get; set; }
        public bool? ReturnStatus { get; set; }
        public long? Delaypenalty { get; set; }
        public DateTime? ReciveDate { get; set; }
        public string ReciveDateString { get; set; }
        public int Count { get; set; }

        public int? DayNo { get; set; }
        public string CancelReason { get; set; }
        public string? Status { get; set; }

    }
}
