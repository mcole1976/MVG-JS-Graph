using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Graphing_and_Progress.Service;
using Graphing_and_Progress.Models;
using Microsoft.CodeAnalysis;
using ExerciseMethodShareDtNt;

namespace Graphing_and_Progress.Controllers
{
    public class FoodController : Controller
    {

        private readonly Data_Service _dataService;
        // GET: FoodController
        public ActionResult Index()
        {
            Data_Service ds = new Data_Service(-75, 0);
            List<Models.Food_log> meals = new List<Food_log>();

            foreach(Food_Log f in ds.MealCollection.ToList() )
            {
                Models.Food_log foody = new Models.Food_log();
                foody.Calorie_Count = f.Calorie_Count;
                foody.Date = f.Date;
                foody.Meal_Description = f.Meal_Description;
                foody.Meal = f.Meal;


                meals.Add(foody);
            }

            var dateCaloriesDictionary = CreateDateCaloriesDictionary(meals);
            List<KeyValuePair<DateOnly, int>> dataKVP = new List<KeyValuePair<DateOnly, int>>();
            foreach (var  v in dateCaloriesDictionary)
            {

                DateOnly d = v.Key;
                int total = v.Value;
                KeyValuePair<DateOnly, int> itteration = new KeyValuePair<DateOnly, int>(d, total);
                dataKVP.Add(itteration);
            }


            return View(dataKVP);
        }

        public static Dictionary<DateOnly , int> CreateDateCaloriesDictionary(List<Food_log> meals)
        {
            var dateCaloriesDictionary = meals.GroupBy(log => DateOnly.FromDateTime(log.Date)).ToDictionary(
                group => group.Key, 
                group => group.Sum(log => log.Calorie_Count)); 
            return dateCaloriesDictionary;
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
