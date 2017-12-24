
using System;
using XamChat.Core.Contracts;
using XamChat.Core.Services;

namespace XamChat.Core.ViewModels
{
	public class BaseViewModel
	{
		protected readonly IWebService service = ServicesContainer.Resolve<IWebService>();
		protected readonly ISettings settings = ServicesContainer.Resolve<ISettings>();

		public event EventHandler IsBusyChanged = delegate { };

		private bool isBusy = false;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				IsBusyChanged(this, EventArgs.Empty);
			}
		}
	}
}
