﻿using GuildWars2Guild.Classes.Logger;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GuildWars2Guild.Classes.MVVM.Sorting
{
    public class CustomSortBehaviour
    {
        public static readonly DependencyProperty CustomSorterProperty = DependencyProperty.RegisterAttached("CustomSorter", typeof(ICustomSorter), typeof(CustomSortBehaviour));

        public static ICustomSorter GetCustomSorter(DataGridColumn gridColumn) => (ICustomSorter)gridColumn.GetValue(CustomSorterProperty);

        public static void SetCustomSorter(DataGridColumn gridColumn, ICustomSorter value) {
            gridColumn.SetValue(CustomSorterProperty, value);
        }

        public static readonly DependencyProperty AllowCustomSortProperty = DependencyProperty.RegisterAttached("AllwCustomSort", typeof(bool), typeof(CustomSortBehaviour), new UIPropertyMetadata(false, OnAllowCustomSortChanged));

        public static bool GetAllowCustomSort(DataGrid grid) => (bool)grid.GetValue(AllowCustomSortProperty);

        public static void SetAllowCustomSort(DataGrid grid, bool value) {
            grid.SetValue(AllowCustomSortProperty, value);
        }

        private static void OnAllowCustomSortChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var existing = d as DataGrid;
            if(existing == null)
                return;

            var oldAllow = (bool)e.OldValue;
            var newAllow = (bool)e.NewValue;

            if(!oldAllow && newAllow) {
                existing.Sorting += HandleCustomSorting;
            }
            else {
                existing.Sorting -= HandleCustomSorting;
            }
        }

        private static void HandleCustomSorting(object sender, DataGridSortingEventArgs e) {
            var dataGrid = sender as DataGrid;
            if(dataGrid == null || dataGrid.ItemsSource == null || !GetAllowCustomSort(dataGrid))
                return;

            var listColView = dataGrid.ItemsSource as ListCollectionView;
            if(listColView == null )
                listColView = new ListCollectionView(dataGrid.ItemsSource as IList);
            
            var sorter = GetCustomSorter(e.Column);
            if(sorter == null) {
                Logger.LogManager.LogMessage<ConsoleLogger>(string.Format("No custom sorter found on the colum {0}", e.Column.Header), LogType.Message);
                return;
            }
            
            e.Handled = true;

            var direction = (e.Column.SortDirection != ListSortDirection.Ascending)
                                ? ListSortDirection.Ascending
                                : ListSortDirection.Descending;

            e.Column.SortDirection = sorter.SortDirection = direction;
            listColView.CustomSort = sorter;
        }
    }

    public interface ICustomSorter : IComparer
    {
        ListSortDirection SortDirection { get; set; }
    }
}
