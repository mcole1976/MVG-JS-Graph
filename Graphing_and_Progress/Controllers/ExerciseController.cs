using ExerciseMethodShareDtNt;
using Graphing_and_Progress.Models;
using Graphing_and_Progress.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graphing_and_Progress.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: ExerciseController
        public ActionResult Index()
        {
            Data_Service ds = new Data_Service(-75, 0, "ex");
            List<Models.Exercise> activities = new List<Exercise>();

            foreach (Exercise_Log f in ds.ExCollection.ToList())
            {
                Models.Exercise exercijio = new Models.Exercise();
                exercijio.Calorie_Count = f.Calorie_Count;
                exercijio.Date = f.Date;
                exercijio.Exercise_Name = f.Exercise_Name;  
                exercijio.Exercise_Time  = f.Exercise_Time;

                activities.Add(exercijio);
            }

            var dateCaloriesDictionary = CreateDateCaloriesDictionary(activities);
            List<KeyValuePair<DateOnly, int>> dataKVP = new List<KeyValuePair<DateOnly, int>>();
            foreach (var v in dateCaloriesDictionary)
            {

                DateOnly d = v.Key;
                int total = v.Value;
                KeyValuePair<DateOnly, int> itteration = new KeyValuePair<DateOnly, int>(d, total);
                dataKVP.Add(itteration);
            }


            return View(dataKVP);
        }

        private static Dictionary<DateOnly,int> CreateDateCaloriesDictionary(List<Exercise> activities)
        {
            var dateCaloriesDictionary = activities.GroupBy(log => DateOnly.FromDateTime(log.Date)).ToDictionary(
                group => group.Key,
                group => group.Sum(log => log.Calorie_Count));
            return dateCaloriesDictionary;
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExerciseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseController/Create
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

        // GET: ExerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExerciseController/Edit/5
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

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExerciseController/Delete/5
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
