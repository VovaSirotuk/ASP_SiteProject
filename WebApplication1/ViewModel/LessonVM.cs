using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class LessonVM 
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        public bool IsRegular { get; set; }
    }
}
