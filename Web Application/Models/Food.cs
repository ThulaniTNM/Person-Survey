using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web_Application.Models {
    /*
     Things to be removed.
        1. FoodDetails property,replace with database , Keys and value has same structure as database table. Use those instead for consistecy.
        2. FoodDetails property instantiation in constructor.
     */
    public class Food {
        /*Start of database design*/
        [Key]
        public int FoodID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PersonFood> PersonFoods { get; set; }
        /*End of database design*/

        //Structure for generating view.


        [NotMapped]
        public Dictionary<string,string> FoodDetails { get; set; }  // Food structure ,use to generate its value in the view only.
       
        [NotMapped]
        // use for getting key of the selected food user selects.
        //  use for generating checkbox for each available food that user can select.
        public Dictionary<string,bool> SelectedFood { get; set; } 

        // Use constructor to set key and default value for selectedFood property before user selects.
        public Food( ) {

            // This data not important ,can be replaced by db data for constistency.
            FoodDetails = new Dictionary<string, string>() {
                {"1","Pizza" },
                {"2","Pasta" },
                {"3","Pap and Wors" },
                {"4","Chicken Stir Fry" },
                {"5","Beef Stir Fry" },
                {"6","Other" },
            };

            // user has not selected food when view is rendered so set value to false for food not selected.
            // Key  used to keep track of which food item has been selected.
            // selectedFood item will have value changed to true.
            // will use its key to obtain information of selected food item(true value) from db
            SelectedFood = new Dictionary<string, bool>();
            for (int i = 1; i< 7; i++) {
                SelectedFood.Add(i.ToString(), false);
            }



        }
    }
     
}