using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Application.Models {
    public class PersonSurveyDBContext :DbContext {

        public DbSet<Person> People { get; set; }
        public DbSet<Food>  Foods { get; set; }
        public DbSet<Liking> Likings { get; set; }
        public DbSet<PersonFood> PersonsFoods { get; set; }
        public DbSet<PersonLiking> PersonsLikings { get; set; }
        public PersonSurveyDBContext(): base("PersonSurveyDatabase") {

        }
    }
}