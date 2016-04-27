using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GuildWars2Guild.Controls.Widgets
{
    /// <summary>
    /// Interaction logic for NumericTextBox.xaml
    /// </summary>
    public partial class NumericTextBox : UserControl
    {
        public static readonly DependencyProperty HintProperty = DependencyProperty.Register("Hint", typeof(string), typeof(NumericTextBox), new PropertyMetadata(""));
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(NumericTextBox), new PropertyMetadata(""));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        public NumericTextBox() {
            InitializeComponent();
        }

        private void TextBox_Keyword_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }
    }
}
