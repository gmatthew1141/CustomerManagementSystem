using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness {

    public class Booking {
        public int BookingId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int StartTime { get; set; }

        [Required]
        public int Duration { get; set; }

        public int EndTime { get; set; }

        [Required]
        public SportType SportType { get; set; }

        public int CourtNum { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int NumOfPlay { get; set; }

        [Required]
        public int NumOfPlayed { get; set; }

        public int NumOfPlayedLeft { get; set; }
        public string Note { get; set; }
    }
}