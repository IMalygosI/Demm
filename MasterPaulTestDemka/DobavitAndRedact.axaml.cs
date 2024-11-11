using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPaulTestDemka.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MasterPaulTestDemka;

public partial class DobavitAndRedact : Window
{
    public Partner partnerSuor;
    public DobavitAndRedact()
    {
        InitializeComponent();
        partnerSuor = new Partner();
    }
    public DobavitAndRedact(Partner ff)
    {
        InitializeComponent();
        partnerSuor = ff;
        DobavitAndRedactGrid.DataContext = partnerSuor;
    }

    private void ButtonSave(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        if (partnerSuor.IdPartners != 0)
        {
            Helper.DataBase.Partners.Update(partnerSuor);
            Helper.DataBase.SaveChanges();
            Close();
        }
        else
        {
            Helper.DataBase.Partners.Add(partnerSuor);
            Helper.DataBase.SaveChanges();
            Close();
        }
    }
    private void ButtonExit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}