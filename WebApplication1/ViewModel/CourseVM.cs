using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
	public class CourseVM
	{
        [Required]
        public int CourseId { get; set; }
        [Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
	}
}
