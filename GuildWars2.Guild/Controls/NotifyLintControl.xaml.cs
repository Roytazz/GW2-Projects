using GuildWars2.Guild.Classes;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GuildWars2.Guild.Controls
{
    /// <summary>
    /// Interaction logic for NotifyLintControl.xaml
    /// </summary>
    public partial class NotifyLintControl : UserControl
    {
        public NotifyLintControl() {
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
