namespace WebApplication1.Models
{
    public class Lesson
    {
        public int LessonId { get; set; } // Первинний ключ, унікальний ідентифікатор уроку
        public int CourseId { get; set; } // Ідентифікатор курсу, зв'язок з таблицею Courses
        public string Title { get; set; } // Назва уроку
        public DateTime ScheduledDate { get; set; } // Дата проведення уроку
        public bool IsRegular { get; set; }

        public Course Course { get; set; }
    }
}
/*Таблиця Events зберігає інформацію про події,     які можуть бути створені адміністраторами або іншими користувачами. Події можуть включати вебінари, зустрічі або інші важливі дати.*/