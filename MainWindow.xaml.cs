﻿//Koodannut ja testannut toimivaksi 6.3.2014 SA.
using System;
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

namespace H10ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    string YhteysMerkkijono;
    string TaulunNimi;
    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
      YhteysMerkkijono = JAMK.ICT.Properties.Settings.Default.Tietokanta;
      TaulunNimi = JAMK.ICT.Properties.Settings.Default.Taulu;
      //täytetään combobox maiden nimillä
      cbCountries.ItemsSource = JAMK.ICT.Data.DBPlacebo.GetCitiesOfCustomersFromSQLServer(YhteysMerkkijono, TaulunNimi).DefaultView;
      cbCountries.DisplayMemberPath = "city";
    }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
      //dgCustomers.ItemsSource = JAMK.ICT.Data.DBPlacebo.GetTestCustomers().DefaultView;
      dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetTestCustomers().DefaultView;
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        string messu = "";
        dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(YhteysMerkkijono, TaulunNimi, out messu);
        lbMessages.Content = messu;
      }
      catch (Exception ex)
      {
        lbMessages.Content = ex.Message;
      }
     }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
      //TODO
    }
  }
}
