using System;
using System.Threading.Tasks;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
	public partial class LoginController : UIViewController
	{
		readonly LoginViewModel loginViewModel = ServicesContainer.Resolve<LoginViewModel>();

		public LoginController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			loginButton.TouchUpInside += (sender, e) =>
			{
				loginViewModel.Username = UserNameText.Text;
				loginViewModel.Password = passwordText.Text;

				try
				{
					Task.Run(async () => { await loginViewModel.Login(); });
				}
				catch (Exception ex)
				{
					var alert = UIAlertController.Create("Login Failure", ex.Message, UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

					PresentViewController(alert, true, null);
				}
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			loginViewModel.IsBusyChanged += LoginViewModel_IsBusyChanged;
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			loginViewModel.IsBusyChanged -= LoginViewModel_IsBusyChanged;
		}

		void LoginViewModel_IsBusyChanged(object sender, EventArgs e)
		{
			InvokeOnMainThread(() =>
			{
				UserNameText.Enabled = passwordText.Enabled = loginButton.Enabled = indicateActivity.Hidden = !loginViewModel.IsBusy;
			});
		}
	}
}