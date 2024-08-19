using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class PadminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PadminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseVM model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreatedDate = DateTime.Now
                };

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return RedirectToAction("Courses", "Course");
            }
            return View(model);
        }
        // Метод для відображення форми редагування
        [HttpGet]
        public async Task<IActionResult> ChangeCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var model = new Course
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeCourse(CourseVM model) // Метод для обробки змін
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Courses.FindAsync(model.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                course.Title = model.Title;
                course.Description = model.Description;
                course.StartDate = model.StartDate;
                course.EndDate = model.EndDate;

                _context.Courses.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction("Courses", "Course");
            }
            return View(model);
        }
        

        [HttpGet]
        public async Task<IActionResult> AddLesson(int id)
        {
            var model = new LessonVM
            {
                CourseId = id
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> AddLesson(LessonVM model)
        {
            if (ModelState.IsValid)
            {
                var lesson = new Lesson
                {
                    CourseId = model.CourseId,
                    Title = model.Title,
                    ScheduledDate = model.ScheduledDate,
                    IsRegular = model.IsRegular
                };

                _context.Lessons.Add(lesson);
                await _context.SaveChangesAsync();

                return RedirectToAction("Courses", "Course");
            }
            return View(model);
        }
        
    }


}