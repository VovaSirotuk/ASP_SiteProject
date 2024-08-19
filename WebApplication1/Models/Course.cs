namespace WebApplication1.Models
{
    public class Course
    {
        public int CourseId { get; set; } // Первинний ключ, унікальний ідентифікатор курсу
        public string Title { get; set; } // Назва курсу
        public string Description { get; set; } // Опис курсу
        public DateTime StartDate { get; set; } // Дата початку курсу
        public DateTime EndDate { get; set; } // Дата завершення курсу
        public DateTime CreatedDate { get; set; } // Дата створення курсу

        public ICollection<Review> Reviews { get; set; } // Відгуки на курс
        public ICollection<Enrollment> Enrollments { get; set; } // Записи на курс
        public ICollection<Lesson> Lessons { get; set; } // Уроки в межах курсу
    }
}
