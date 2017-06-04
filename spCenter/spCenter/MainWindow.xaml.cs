
using System;
using System.Collections.Generic;
using System.Data;
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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace spCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ShopChanger sch;
        Stack<Control> invisbleObj;
        public MainWindow()
        {
            
            InitializeComponent();
            sch = new ShopChanger();
            InvisibleObjectStack();
            
        }
        private void InvisibleObjectStack()
        {
            invisbleObj = new Stack<Control>();
            invisbleObj.Push(tbox_as);
            invisbleObj.Push(Label_as);
            invisbleObj.Push(shopList_ds);
            invisbleObj.Push(Label_ds);
            invisbleObj.Push(shopList_ap);
            invisbleObj.Push(Label_ap);
            invisbleObj.Push(shopList_dp);
            invisbleObj.Push(Label_dp);
            invisbleObj.Push(shopList_sc);
            invisbleObj.Push(Label_dp_sc);
            invisbleObj.Push(check_as);
            invisbleObj.Push(check_ds);
            invisbleObj.Push(check_ap);
            invisbleObj.Push(check_dp);
            invisbleObj.Push(check_sc);
            invisbleObj.Push(tbox_ap);
            invisbleObj.Push(tbox_dp);
            invisbleObj.Push(Label_ap_up);
            invisbleObj.Push(Label_dp_up);
            
        }
        private void HiddenAll()
        {
            foreach (var item in invisbleObj)
            {
                item.Visibility = Visibility.Hidden;
            }
        }
        
        private void AddShop_Click(object sender, RoutedEventArgs e)
        {

            //sch.AddShop(tbox.Text);   do chcek()
            HiddenAll();
            tbox_as.Visibility = Visibility.Visible;
            Label_as.Visibility = Visibility.Visible;
            check_as.Visibility = Visibility.Visible;
        }

        private void ShowShop(ComboBox shopList)
        {
            shopList.Items.Clear();
            foreach(var item in sch.ShopList())
                shopList.Items.Add(item);
        }

        private void ShowChart_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            shopList_sc.Visibility = Visibility.Visible;
            Label_dp_sc.Visibility = Visibility.Visible;
            check_sc.Visibility = Visibility.Visible;
            ShowShop(shopList_sc);
        }

        private void delateShop_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Label_ds.Visibility = Visibility.Visible;
            shopList_ds.Visibility = Visibility.Visible;
            ShowShop(shopList_ds);
            check_ds.Visibility = Visibility.Visible;
            
        }

        private void check_as_Click(object sender, RoutedEventArgs e)
        {

        }

        private void check_ds_Click(object sender, RoutedEventArgs e)
        {

        }

        private void check_ap_Click(object sender, RoutedEventArgs e)
        {
            if(tbox_dp.Text != null)
                sch.AddShop(tbox_ap.Text);
        }

        private void check_dp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void check_sc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Label_dp.Visibility = Visibility.Visible;
            Label_dp_up.Visibility = Visibility.Visible;
            tbox_dp.Visibility = Visibility.Visible;
            check_dp.Visibility = Visibility.Visible;
            shopList_dp.Visibility = Visibility.Visible;
            ShowShop(shopList_dp);
        }

        private void addPoruct_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Label_ap.Visibility = Visibility.Visible;
            Label_ap_up.Visibility = Visibility.Visible;
            tbox_ap.Visibility = Visibility.Visible;
            check_ap.Visibility = Visibility.Visible;
            shopList_ap.Visibility = Visibility.Visible;
            ShowShop(shopList_ap);

        }
    }
}
