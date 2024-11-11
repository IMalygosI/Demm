using Avalonia.Controls;
using MasterPaulTestDemka.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterPaulTestDemka
{
    public partial class MainWindow : Window
    {
        List<Partner> partners = new List<Partner>();
        public MainWindow()
        {
            InitializeComponent();


            Loang();
        }

        public void Loang()
        {
            partners = Helper.DataBase.Partners.ToList();





            List_Box_MasterPaulTestDemka.ItemsSource = partners;
        }

        private void ListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var ff = List_Box_MasterPaulTestDemka.SelectedItem as Partner;

            DobavitAndRedact dobavitAndRedact = new DobavitAndRedact(ff);
            dobavitAndRedact.ShowDialog(this);
            dobavitAndRedact.Closed += (a, d) => Loang();
        }

        private void Button_Click_Dobavit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DobavitAndRedact dobavit = new DobavitAndRedact();
            dobavit.ShowDialog(this);
            dobavit.Closed += (a, d) => Loang();
        }

        private void Button_Click_Delete(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var T = List_Box_MasterPaulTestDemka.SelectedItem as Partner;
            Helper.DataBase.Partners.Remove(T);
            Helper.DataBase.SaveChanges();
        }

        private void ListBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
        {
            delet.IsVisible = true;
            Loang();
        }
    }
}