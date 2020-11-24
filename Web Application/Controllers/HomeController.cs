using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Web_Application.Models;

namespace Web_Application.Controllers {
    public class HomeController : Controller {

        //Starting Page
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult Index( ) {
            return View();
        }



        [HttpGet]
        public ActionResult PersonSurvey ( ) {
            Person person = new Person();
            return View(person);
        }

        [HttpPost]
        public ActionResult PersonSurvey( Person person ) {

            //For me Delete before submission
            // Model Dictionary validation may be handled here.
            //no need to validate model ,annotations is taking care of it.
            //No need to retrieve PersonID,saving links it.



        
                using (PersonSurveyDBContext db = new PersonSurveyDBContext()) {
                    db.People.Add(person);//save person
                    db.SaveChanges();

                    //Save PersonFoods
                    //Might delete to make code clean
                    //for each true value/selected food value add that person with all the selected food values
                    //person id will repeat itself while food id depends on the true selected food value
                    //Don't save for a person who doesn't have favourite food
                    foreach (KeyValuePair<string, bool> keyValueSelectedFood in person.Food.SelectedFood) {
                        if (keyValueSelectedFood.Value) {
                            db.PersonsFoods.Add(new PersonFood() { PersonID = person.PersonID, FoodID = int.Parse(keyValueSelectedFood.Key) });
                            db.SaveChanges();
                        }
                    }

                    //Save PersonLikings
                    // For a Person's each and every rating, save rating id that person id and the rating value to the PersonLiking table
                    foreach (KeyValuePair<string, string> keyValueSelectedLikings in person.Liking.Options) {
                        if (keyValueSelectedLikings.Value != "" || keyValueSelectedLikings.Value != null) {
                            int likingId = db.Likings.Where(x => x.Likes == keyValueSelectedLikings.Key).ToList().First().LikingID;
                            db.PersonsLikings.Add(new PersonLiking() { PersonID = person.PersonID, LikingID = likingId, LikingValue = keyValueSelectedLikings.Value });
                            db.SaveChanges();
                        }
                    }

                    return View("Index");
                }

               
        }
       
        public ActionResult SurveyResult( ) {

            using(PersonSurveyDBContext db = new PersonSurveyDBContext()) {
                IEnumerable<Person> people = db.People.ToList();


                ViewBag.totalNumSurvey = people.Count(); // 1 

                

                ViewBag.averageAge = people.Select(x => x.Age).Sum()/people.Count(); // 2

                ViewBag.oldestPersonSurvey = people.Select(x => x.Age).Max(); // 3

                ViewBag.youngestPersonSurvey = people.Select(x => x.Age).Min(); // 4

                IEnumerable<PersonFood> personFoodTable = db.PersonsFoods.ToList();

                //for loop dynamically create this data
                //Keep it simple ,review to make more concise
               ViewBag.peoplePizzaPercentage =Math.Round( (personFoodTable.Where(x => x.FoodID == 1).Count() / (decimal)people.Count())*100,1);
               ViewBag.peoplePastaPercentage =Math.Round( (personFoodTable.Where(x => x.FoodID == 2).Count() / (decimal)people.Count())*100,1);
               ViewBag.peoplePapPercentage =Math.Round( (personFoodTable.Where(x => x.FoodID == 3).Count() / (decimal)people.Count())*100,1);

                IEnumerable<PersonLiking> personLikingTable = db.PersonsLikings.ToList();
                ViewBag.peopleEatOutPercentage = Math.Round((personLikingTable.Where(x => x.LikingID == 204).Count() / (decimal)people.Count()) * 100, 1);
                ViewBag.peopleWatchMoviesPercentage = Math.Round((personLikingTable.Where(x => x.LikingID == 205).Count() / (decimal)people.Count()) * 100, 1);
                ViewBag.peopleWatchTVPercentage = Math.Round((personLikingTable.Where(x => x.LikingID == 206).Count() / (decimal)people.Count()) * 100, 1);
                ViewBag.peopleListenRadioPercentage = Math.Round((personLikingTable.Where(x => x.LikingID == 207).Count() / (decimal)people.Count()) * 100, 1);

            }
            return View();
        }
    }
}