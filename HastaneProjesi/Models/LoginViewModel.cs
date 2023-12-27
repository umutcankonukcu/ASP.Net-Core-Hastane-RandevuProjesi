using System.ComponentModel.DataAnnotations;

namespace HastaneProjesi.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage ="Username is required")]
		[StringLength(30,ErrorMessage ="Username can be max 30 characters")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Username is required")]
		[MinLength(6,ErrorMessage = "Password can be min 6 characters")]
		[MaxLength(16, ErrorMessage = "Password can be max 16 characters")]
		public string Password { get; set; }
	}

	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Username is required")]
		[StringLength(30, ErrorMessage = "Username can be max 30 characters")]
		public string Username { get; set; }
		
		[Required(ErrorMessage = "Age is required")]
		public int Age { get; set; }

		[Required(ErrorMessage = "Mail is required")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Username is required")]
		[MinLength(6, ErrorMessage = "Password can be min 6 characters")]
		[MaxLength(16, ErrorMessage = "Password can be max 16 characters")]
		public string Password { get; set; }

		
		
	}
}
