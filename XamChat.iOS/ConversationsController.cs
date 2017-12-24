using System;
using UIKit;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.iOS
{
    public partial class ConversationsController : UITableViewController
    {
        readonly MessageViewModel messageViewModel = ServicesContainer.Resolve<MessageViewModel>();

        public ConversationsController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.Source = new ConversationsTableSource();
        }

        public async override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            try
            {
                await messageViewModel.GetConversations();

                TableView.ReloadData();
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