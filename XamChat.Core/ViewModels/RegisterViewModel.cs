
using System;
using System.Threading.Tasks;
using XamChat.Core.Models;

namespace XamChat.Core.ViewModels
{
	public class RegisterViewModel : BaseViewModel
	{
		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string ConfirmPassword
		{
			get;
			set;
		}

		public async Task Register()
		{
			if (string.IsNullOrEmpty(UserName))
			{
				throw new Exception("User name is blank");
			}

			if (string.IsNullOrEmpty(Password))
			{
				throw new Exception("Password is blank");
			}

			if (Password != ConfirmPassword)
			{
				throw new Exception("Passwords do not match.");
			}

			IsBusy = true;
			try
			{
				settings.Usr = await service.Register(new User { UserName = this.UserName, Password = this.Password });
				settings.Save();
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
