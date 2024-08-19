using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } // Ім'я користувача
        public string LastName { get; set; } // Прізвище користувача
        public DateTime CreatedDate { get; set; } // Дата створення облікового запису
        public DateTime? LastLoginDate { get; set; } // Остання дата входу в систему, може бути null

        public ICollection<Review> Reviews { get; set; } // Відгуки, залишені користувачем
        public ICollection<Enrollment> Enrollments { get; set; } // Записи на курси
    }
}
/*Таблиця Users зберігає основну інформацію про користувачів системи, включаючи їхні ролі, 
 * які визначаютm права доступу до різних функціональних можливостей (наприклад, адміністратор 
 * має доступ до управління курсами та користувачами, звичайний користувач – ні).*/
