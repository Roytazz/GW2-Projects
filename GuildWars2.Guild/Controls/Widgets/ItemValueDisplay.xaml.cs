using GuildWars2.API.Model.Commerce;
using System.Windows;
using System.Windows.Controls;

namespace GuildWars2.Guild.Controls.Widgets
{
    /// <summary>
    /// Interaction logic for ItemValue.xaml
    /// </summary>
    public partial class ItemValueDisplay : UserControl
    {
        public ItemValueDisplay() {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(ItemPrice), typeof(ItemValueDisplay), new PropertyMetadata(null));
        public ItemPrice Value
        {
            get { return (ItemPrice)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
