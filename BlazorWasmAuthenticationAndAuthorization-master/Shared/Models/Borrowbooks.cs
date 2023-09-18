using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Models
{
    public partial class Borrowbooks
    {
        public int BorrowbookID { get; set; }

        [Required]
        public int? BookID { get; set; } = null!;

        [Required]
        public string Borrowername { get; set; } = null!;
        [Required]
        public string NationalID { get; set; } = null!;

        //[Required]
        public DateTime? borrowDate { get; set; } = null!;
        [Required]

        public DateTime? Returndate { get; set; } = null!;
        [Required]
        public long? Price { get; set; }
        public bool? ReturnStatus { get; set; }
        public long? Delaypenalty { get; set; }
        public DateTime? ReciveDate { get; set; }
        public string? BookName { get; set; }
        public int? DayNo { get; set; }
        public string? CancelReason { get; set; }
        public string? Status { get; set; }

    }
}
