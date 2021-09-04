using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ORM
{
    public class ProductManager
    {
        public static List<Product> GetProductList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Products
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static Product GetProductInfo(int ProductID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Products
                         where item.ProductID == ProductID
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static Product GetProductInfoByName(string productName)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Products
                         where item.ProductName == productName
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static void CreateProduct(Product productInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    productInfo.Discontinued = 1;
                    context.Products.Add(productInfo);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateProduct(Product productInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Products.Where(obj => obj.ProductID == productInfo.ProductID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.ProductName = productInfo.ProductName;
                        dbObject.UnitPrice = productInfo.UnitPrice;
                        dbObject.WeightPerUnit = productInfo.WeightPerUnit;
                        dbObject.ManufactureDate = productInfo.ManufactureDate;
                        dbObject.ExpirationDate = productInfo.ExpirationDate;
                        dbObject.Body = productInfo.Body;
                        dbObject.Discontinued = productInfo.Discontinued;
                        dbObject.Photo = productInfo.Photo;

                        context.SaveChanges();
                        
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
    }
}
