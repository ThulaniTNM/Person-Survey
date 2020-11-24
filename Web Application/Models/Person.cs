using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//C: \Users\User\Desktop\Programs\Package Apps\mvc\Template no auth\Web Application\
namespace Web_Application.Models {
    public class Person {
        /*Start of database design*/
        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Surname required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "First Names")]
        public string FirstNames { get; set; }

        /*Self made expression ^(\+27|0)[\s-]?(\d{9}|(\d{2}-\d{3}-\d{4})|(\d{2}\s\d{3}\s\d{4})|(\d{2}[\s-]\d{7}))$
                   All possible numbers in south africa.

                    +27760518556
                    0760518556

                   +2776-051-8556
                    076-051-8556

                    +27 76 051 8556
                     076 051 8556
                    +27 76-051-8556
                    

                    076 0518556
                    076-0518556
                    +27-765339085
         */
        [Required(ErrorMessage = "Contact required")]
        [RegularExpression(@"^(\+27|0)[\s-]?(\d{9}|(\d{2}-\d{3}-\d{4})|(\d{2}\s\d{3}\s\d{4})|(\d{2}[\s-]\d{7}))$", ErrorMessage = "Please enter valid phone no Eg 076305185566")] // Review reqular expression
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Date of birth required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Age required")]
        [Range(5, 120, ErrorMessage = "Age should be between 5 and 120")]
        public int Age { get; set; }
        public virtual ICollection<PersonFood> PersonFoods { get; set; }
        public virtual ICollection<PersonLiking> PersonLikings { get; set; }

        /*End of database design*/


        // Food and liking selected collected from the form
        [NotMapped]
        public Food Food { get; set; }

        [NotMapped]
        public Liking Liking { get; set; }

        public Person( ) {
            Food = new Food();
            Liking = new Liking();
        }
    }
}