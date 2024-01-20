using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Entities.ViewModels
{
	public class EmployeeViewModel
	{
		[Key]
		[Display(Name = "Employee Id")]
		[Required]
		public int EmployeeId { get; set; }

		[Display(Name = "Employee Name")]
		[StringLength(maximumLength: 20, ErrorMessage = "The Title length should be between 2 and 20.", MinimumLength = 2)]
		public string EmployeeName { get; set; } = string.Empty;

		public double Salary { get; set; }
	}
}
