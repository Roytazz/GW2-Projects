using GuildWars2API.Model.Items;
using System.Windows;
using System.Windows.Controls;

namespace GuildWars2Guild.Controls.Widgets
{
    /// <summary>
    /// Interaction logic for ItemDisplay.xaml
    /// </summary>
    public partial class ItemDisplay : UserControl
    {
        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(Item), typeof(ItemDisplay), new PropertyMetadata(null));
        public Item Item
        {
            get { return (Item)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public ItemDisplay() {
            InitializeComponent();
        }
    }
}
