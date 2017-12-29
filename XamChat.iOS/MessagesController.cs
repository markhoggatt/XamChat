
using System;
using System.Threading.Tasks;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;
using XamChat.iOS.TableViewSources;

namespace XamChat.iOS
{
	public partial class MessagesController : UITableViewController
	{
		readonly MessageViewModel messageViewModel = ServicesContainer.Resolve<MessageViewModel>();

		public MessagesController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var messagesSource = new MessagesTableSource();
			TableView.Source = messagesSource;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			try
			{
				Task.Run(async () =>
				{
					await messageViewModel.GetMessages();
					InvokeOnMainThread(() =>
					{
						Title = messageViewModel.Conversation.Username;
						TableView.ReloadData();
					});
				});
			}
			catch (Exception ex)
			{
				var alert = UIAlertController.Create("No Messages", ex.Message, UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

				PresentViewController(alert, true, null);
			}
		}
	}
}