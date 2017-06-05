using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spCenter
{
    public class ShopChanger
    {
        DataBase.DatabaseConnecting dc;
        public ShopChanger()
        {
            dc = new DataBase.DatabaseConnecting();
        }
        public IList ShopList()
        {
            List<int> shopIds = dc.Select("select shop_id from shops");
            return shopIds;
        }
        public void AddShop(string region)
        {
            int simplyValue = 0;
            foreach(int item in ShopList())
            {
                simplyValue = item + 1;
            }
            dc.Insert("insert into shops values (" + simplyValue.ToString() + ", '" + region + "' )");
        }
        public void DeleteShop(string id)
        {
            dc.Delete("delete from shops where shop_id = " + id);
        }
        public void AddProduct(string shop_id, string name)
        {
            int simplyValue = 0;
            foreach (int item in ProductList())
            {
                simplyValue = item + 1;
            }
            dc.Insert("insert into product values (" + simplyValue + ", '" + name + "', " + shop_id + ")");
        }
        public void DeleteProduct(string name)
        {

            dc.Delete("delete form product where product_name =" + name);
        }
        private IList ProductList()
        {
            List<int> prodIds = dc.Select("select product_id from product");
            return prodIds;
        }
        public IList ProductName()
        {
            List<string> prodNames = dc.SelectString("select product_name from product");
            return prodNames;

        }
        public IList ProductNamewhere(string shop_id)
        {
            List<string> prodNames = dc.SelectString("select product_name from product where shop_in = " + shop_id);
            return prodNames;

        }
    }
}
