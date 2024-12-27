using CreateExercises;
using ExerciseMethodShareDtNt;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Graphing_and_Progress.Service
{
    public class Data_Service
    {
        private readonly List<ExerciseMethodShareDtNt.Food_Log> _mealCollection;
        private readonly List<ExerciseMethodShareDtNt.Exercise_Log> _exCollection;
        public List<Food_Log> MealCollection => _mealCollection;

        public List<Exercise_Log> ExCollection => _exCollection;

        public Data_Service(int DateFrom, int DateTo) 
        {

            _mealCollection = fnSet_Logs(DateFrom, DateTo);


        }
        public Data_Service(int DateFrom, int DateTo, string e)
        {

            //_mealCollection = fnSet_Logs(DateFrom, DateTo);
            _exCollection = fnSet_Exercise(-75, 0);

        }

        private List<Exercise_Log> fnSet_Exercise(int v1, int v2)
        {
            List<Exercise_Log> ex = CreateExercises.ExerciseDataFeed.ExerciseLogs();
            DateTime dy1 = DateTime.Today;

            DateTime marker1 = dy1.AddDays(v1);
            DateTime marker2 = dy1.AddDays(v2);

            ex = (from exL in ex where exL.Date >= marker1 && exL.Date < marker2 select exL).ToList();
            return ex;
        }

        private List<Food_Log> fnSet_Logs(int dateFrom, int dateTo)
        {
            List<Food_Log> f = CreateExercises.ExerciseDataFeed.FoodLogs();
            try
            {
                
                DateTime dy1 = DateTime.Today;

                DateTime marker1 = dy1.AddDays(dateFrom);
                DateTime marker2 = dy1.AddDays(dateTo);

                f = (from exL in f where exL.Date >= marker1 && exL.Date < marker2 select exL).ToList();
            }
            catch (Exception ex) { }
            return f;
        }
    }
}
