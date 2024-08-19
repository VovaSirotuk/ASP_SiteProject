namespace WebApplication1.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; } // Первинний ключ
        public int CourseId { get; set; } // Зовнішній ключ до таблиці Courses
        public string UserId { get; set; } // Зовнішній ключ до таблиці Users (AppUser)
        public DateTime EnrollmentDate { get; set; } // Дата запису на курс

        public Course Course { get; set; } // Навігаційна властивість до курсу
        public AppUser User { get; set; } // Навігаційна властивість до користувача
    }
}

/*Таблиця Enrollments відслідковує, які користувачі записані на які курси, дозволяючи інструкторам
 * бачити список студентів, а також автоматично відправляти їм повідомлення або нагадування.*/
