using System.Collections.Generic;

namespace WebApplication1.Resource
{
    public static class Cookie
    {
        public static List<shoppingCart_cookie> Cookiereader_shoppingcart(string cookieshoping)
        {
            List<shoppingCart_cookie> shoppingcartlist = new List<shoppingCart_cookie>();

            if (cookieshoping != null)
            {
                string[] shoppingCartCookies1 = Splitter.stringsplitter(cookieshoping, "_");

                foreach (string item in shoppingCartCookies1)
                {
                    string[] result = item.Split("-");
                    if (result.Length == 2)
                    {
                        shoppingcartlist.Add(new shoppingCart_cookie()
                            {ProductID = int.Parse(result[0]), Quantity = int.Parse(result[1])});
                    }
                }
            }

            return shoppingcartlist;
        }

    }

    public class shoppingCart_cookie
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}