
using Microsoft.AspNetCore.Identity;

namespace SMSSMSystem.Core.Models
{
	public class Account: IdentityUser<Guid>
	{
		public string? FullName {  get; set; }
		public string? Phone {  get; set; }
		public DateTime? DateOfBirth { get; set; }
		public byte[] Image { get; set; }

	}
}
