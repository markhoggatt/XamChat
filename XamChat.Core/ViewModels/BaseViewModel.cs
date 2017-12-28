
using System;
using XamChat.Core.Contracts;
using XamChat.Core.Services;

namespace XamChat.Core.ViewModels
{
	public class BaseViewModel
	{
		protected readonly IWebService service = ServicesContainer.Resolve<IWebService>();
		protected readonly ISettings settings = ServicesContainer.Resolve<ISettings>();

		public event EventHandler<EventArgs> IsBusyChanged;

		private bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				IsBusyChanged?.Invoke(this, new EventArgs());
			}
		}
	}
}
