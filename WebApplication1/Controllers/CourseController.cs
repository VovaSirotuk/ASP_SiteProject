using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();

            return View(courses);
        }
    }
}
