using System.ComponentModel.DataAnnotations;

namespace EnglishTest.Models
{
    public class Parameters
    {
        public Trainings UserTraining { get; set; }
        public Conditions UserCondition { get; set; }
        public Levels UserLevel { get; set; }
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

        public enum Levels
        {
            B1,
            B2
        }

        public enum Conditions
        {
            [Display(Name = "До конца заданий")]
            End,
            [Display(Name = "До первой ошибки")]
            OneMistake,
            [Display(Name = "Ограничение по времени (в секундах)")]
            Timer
        }
    }
}
