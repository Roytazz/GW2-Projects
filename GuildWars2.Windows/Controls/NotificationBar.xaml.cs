using GuildWars2Windows.Classes;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GuildWars2Windows.Controls
{
    /// <summary>
    /// Interaction logic for NotificationBar.xaml
    /// </summary>
    public partial class NotificationBar : UserControl
    {
        public NotificationBar() {
            InitializeComponent();

            NotifyHandler.NotificationAdded += NotifyHandler_ShowNotification;
        }

        private void NotifyHandler_ShowNotification(object sender, NotifyEventArgs e) {
            App.Current.Dispatcher.Invoke(delegate {
                TextBlock_Notification.Text = e.Notification;
                Storyboard sb = this.FindResource("ShowNotification") as Storyboard;
                sb.Begin();
            });
        }
    }
}
