using GuildWars2API.Model.Value;
using System.Windows;
using System.Windows.Controls;

namespace GuildWars2Guild.Controls.Widgets
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
