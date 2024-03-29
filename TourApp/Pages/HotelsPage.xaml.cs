﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourApp.Models;

namespace TourApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
            //DGridHotels.ItemsSource = Models.TourBaseEntities.GetContext().Hotels.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.PageManager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.PageManager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Really wanna detele {hotelsForRemoving.Count()} elements?", "Attention!", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                try {
                    Models.TourBaseEntities.GetContext().Hotels.RemoveRange(hotelsForRemoving);
                    Models.TourBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Successfuly deleted");

                    DGridHotels.ItemsSource = Models.TourBaseEntities.GetContext().Hotels.ToList();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if (Visibility == Visibility.Visible) {
                //Models.TourBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                //DGridHotels.ItemsSource = Models.TourBaseEntities.GetContext().Hotels.ToList();
            }
        }
    }
}
