using System;
using System.Threading.Tasks;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
	public partial class ConversationsController : UITableViewController
	{
		readonly MessageViewModel messageViewModel = ServicesContainer.Resolve<MessageViewModel>();

		public ConversationsController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var convSrceDel = new ConversationsTableSource();
			TableView.Source = convSrceDel;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			try
			{
				Task.Run(async () =>
				{
					await messageViewModel.GetConversations();
					InvokeOnMainThread(() =>
					{
						Title = "Conversations";
						TableView.ReloadData();
					});
				});
			}
			catch (Exception ex)
			{
				var alert = UIAlertController.Create("Conversations Failure", ex.Message, UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

				PresentViewController(alert, true, null);
			}
		}
	}
}