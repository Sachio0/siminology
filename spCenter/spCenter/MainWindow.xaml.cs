
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
using System.Windows.Controls.DataVisualization.Charting;

namespace spCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ShopChanger sch;
        Stack<Control> invisbleObj;
        List<TextBlock> tblist0;
        List<TextBlock> tblist1;
        List<TextBlock> tblist2;

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
            invisbleObj.Push(productList_dp);
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
        private void TbToList()
        {
            tblist0.Add(tb00);
            tblist0.Add(tb01);
            tblist0.Add(tb02);
            tblist0.Add(tb03);
            tblist0.Add(tb04);
            tblist0.Add(tb05);
            tblist1.Add(tb10);
            tblist1.Add(tb11);
            tblist1.Add(tb12);
            tblist1.Add(tb13);
            tblist1.Add(tb14);
            tblist1.Add(tb15);
            tblist2.Add(tb20);
            tblist2.Add(tb21);
            tblist2.Add(tb22);
            tblist2.Add(tb23);
            tblist2.Add(tb24);
            tblist2.Add(tb25);

        }
        
        private void AddShop_Click(object sender, RoutedEventArgs e)
        {

            
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
        private void ShowProduct (ComboBox productList)
        {
            productList.Items.Clear();
            foreach (var item in sch.ProductName())
                productList.Items.Add(item);
        }
       

        private void ShowChart_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            shopList_sc.Visibility = Visibility.Visible;
            Label_dp_sc.Visibility = Visibility.Visible;
            check_sc.Visibility = Visibility.Visible;
            myChart.Visibility = Visibility.Visible;
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
            if (tbox_as.Text != null)
                sch.AddShop(tbox_as.Text);
            HiddenAll();
        }

        private void check_ds_Click(object sender, RoutedEventArgs e)
        {
            if(shopList_ds != null)
                sch.DeleteShop(shopList_ds.Text);
            HiddenAll();
        }

        private void check_ap_Click(object sender, RoutedEventArgs e)
        {
            if(shopList_ap.Text != null && tbox_ap != null)
                sch.AddProduct(shopList_ap.Text, tbox_ap.Text);
            HiddenAll();
        }
        private bool ValueInProdList(string value)
        {
            if(sch.ProductNamewhere(shopList_dp.Text).Contains(value))
                return true;
            else
                return false;

        }
        private void check_dp_Click(object sender, RoutedEventArgs e)
        {
            if (ValueInProdList(productList_dp.Text) && shopList_dp != null && productList_dp != null)
                sch.DeleteProduct(productList_dp.Text);
            HiddenAll();
        }

        private void check_sc_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            myChart.Visibility = Visibility.Visible;
            TbToList();
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {
            HiddenAll();
            Label_dp.Visibility = Visibility.Visible;
            Label_dp_up.Visibility = Visibility.Visible;
            productList_dp.Visibility = Visibility.Visible;
            check_dp.Visibility = Visibility.Visible;
            shopList_dp.Visibility = Visibility.Visible;
            ShowShop(shopList_dp);
            ShowProduct(productList_dp);
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
