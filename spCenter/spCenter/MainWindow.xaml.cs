
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
        public MainWindow()
        {
            InitializeComponent();
            sch = new ShopChanger();
            //this.ShowShop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string oradb = "DATA SOURCE=155.158.112.45:1521/OLTPSTUD;PERSIST SECURITY INFO=True;USER ID=MSBD9;PASSWORD=now123";

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = oradb;

                conn.Open();

                OracleCommand cmd = conn.CreateCommand();


                cmd.CommandText = "SELECT NAME FROM DEPT WHERE ID = 10";//"SELECT SHOP_ID FROM SHOP WHERE REGION = 'SLASK'";


                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    txbox.Text = dr.GetString(0) + " \n";
                conn.Close();
            }
            catch (Exception ex)
            {
                txbox.Text = ex.Message;
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
        private void ShowShop()
        {

            shopList.Items.Add(sch.ShopList());
        }
    }
}
