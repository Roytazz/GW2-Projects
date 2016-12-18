using GuildWars2Windows.Classes.Collections;
using GuildWars2Windows.Model;
using GuildWars2API;
using GuildWars2API.Model.Items;
using System.Threading;
using System.Windows.Controls;

namespace GuildWars2Windows.Windows.Pages
{
    /// <summary>
    /// Interaction logic for Crafting.xaml
    /// </summary>
    public partial class Crafting : Page
    {
        public Crafting() {
            InitializeComponent();
            var itemSource = new PropChangeObservableCollection<DisplayRecipeTree>();
            itemSource.Add(new DisplayRecipeTree(ItemAPI.SearchItem("Arachnophobia")[0]));
            Crafting_Treeview.ItemsSource = itemSource;
        }

        public void StartCrafting(Item item) {
            var thread = new Thread(new ThreadStart(delegate {
                if(item.GetType() == typeof(Item)) {
                    //SHOW LOADING ICON
                    //treeviewItemSource.PopulateTree(item as Item);
                    //HIDE LOADING ICON
                }
            }));
            thread.Name = "Thread_PopulateCraftingTree";
            thread.Start();
        }
    }
}