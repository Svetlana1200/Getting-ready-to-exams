using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishTest.Models
{
    public class Parameters
    {
        public string UserTraining { get; set; }
        public string UserCondition { get; set; }
        public string UserLevel { get; set; }
        public int Time { get; set; }
        public int TasksNumber { get; set; }

        public enum Trainings
        {
            [Display(Name = "Все задания")]
            All,
            [Display(Name = "Предложения")]
            Sentences,
            [Display(Name = "Тексты")]
            Texts,
            [Display(Name = "Картинки")]
            Images
        }

        //public enum Levels
        //{
        //    [Display(Name = "B1")]
        //    B1,
        //    [Display(Name = "B2")]
        //    B2,
        //}

        public List<string> Levels = new List<string> { "B1", "B2" };

        public Dictionary<string, string> Conditions = new Dictionary<string, string>
        {
            { "end",  "До конца заданий" },
            { "oneMistake", "До первой ошибки" },
            { "timer", "Ограничение по времени" }
        };
    }
}
