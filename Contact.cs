using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
	public class Contact
	{
		[Required]
		public string Name { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required, StringLength(200)]
		public string Message { get; set; }
	}
}