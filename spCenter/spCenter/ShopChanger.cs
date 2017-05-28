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
            List<string> shopIds = dc.Select("select shop_id from shops");
            return shopIds;
        }
    }
}
