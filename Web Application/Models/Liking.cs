using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Application.Models {
    public class Liking {
        public int LikingID { get; set; }
        [Required(ErrorMessage = "Please Select Rating")] //use this name during binding and validation of selected rating

        public string Likes { get; set; }
        [NotMapped]
        public string LikingValue { get; set; }

        public virtual ICollection<PersonLiking> PersonLikings { get; set; }

        [NotMapped]
       
        public Dictionary<string, string> Options { get; set; } // Use in view for liking options and selected liking.

        public Liking( ) {
            Options = new Dictionary<string, string>() {
                {"I like to eat out",null },
                {"I like to watch movies",null },
                {"I like to watch TV",null },
                {"I like to listen to the radio",null },
            };
        }
    
    }
}