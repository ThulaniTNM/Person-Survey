using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Application.Models {
    public class PersonLiking {

        [Key]
        public int PersonFoodID { get; set; }

        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person Person { get; set; }


        public int LikingID { get; set; }
        [ForeignKey("LikingID")]
        public Liking   Liking { get; set; }

        public string LikingValue { get; set; }
    }
}