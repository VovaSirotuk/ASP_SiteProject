namespace WebApplication1.Models
{
    public class Review
    {
        public int ReviewId { get; set; } // Первинний ключ
        public string UserId { get; set; } // Зовнішній ключ до таблиці Users (AppUser)
        public int CourseId { get; set; } // Зовнішній ключ до таблиці Courses
        public string Content { get; set; } // Текст відгуку
        public DateTime CreatedDate { get; set; } // Дата створення відгуку

        public AppUser User { get; set; } // Навігаційна властивість до користувача
        public Course Course { get; set; } // Навігаційна властивість до курсу
    }
}
