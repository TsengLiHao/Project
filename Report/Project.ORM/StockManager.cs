using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ORM
{
    public class StockManager
    {
        public static List<Stock> GetStockList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
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

        public static Stock GetStockInfo(int stockID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         where item.StockID == stockID
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
        public static Stock GetStockInfoByProductName(string productName)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
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

        public static void CreateProduct(Stock stockInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    stockInfo.ChangedDate = DateTime.Now;
                    context.Stocks.Add(stockInfo);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateStockInfo(Stock stockInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Stocks.Where(obj => obj.StockID == stockInfo.StockID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.ProductName = stockInfo.ProductName;
                        dbObject.CurrentQuantity = stockInfo.CurrentQuantity;
                        dbObject.OrderedQuantity = stockInfo.OrderedQuantity;
                        dbObject.ProductStatus = stockInfo.ProductStatus;
                        dbObject.ChangedDate = DateTime.Now;

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

        public static bool UpdateStockByOrder(Order orderInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         where item.ProductName == orderInfo.ProductName
                         select item);

                    var dbObject = query.FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.OrderedQuantity += orderInfo.OrderedQuantity;
                        dbObject.ChangedDate = DateTime.Now;
                        dbObject.CurrentQuantity -= orderInfo.OrderedQuantity;

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

        public static bool UpdateStockByCancel(Order orderInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         where item.ProductName == orderInfo.ProductName
                         select item);

                    var dbObject = query.FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.OrderedQuantity -= orderInfo.OrderedQuantity;
                        dbObject.ChangedDate = DateTime.Now;
                        dbObject.CurrentQuantity += orderInfo.OrderedQuantity;

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

        public static bool UpdateStockByRevise(Order orderInfo,int originallyQuantity)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         where item.ProductName == orderInfo.ProductName
                         select item);

                    var dbObject = query.FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.OrderedQuantity -= (originallyQuantity - orderInfo.OrderedQuantity);
                        dbObject.ChangedDate = DateTime.Now;
                        dbObject.CurrentQuantity += (originallyQuantity - orderInfo.OrderedQuantity);

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

        public static bool UpdateStockByDelete(Order orderInfo, int originallyQuantity)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         where item.ProductName == orderInfo.ProductName
                         select item);

                    var dbObject = query.FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.OrderedQuantity -= originallyQuantity;
                        dbObject.ChangedDate = DateTime.Now;
                        dbObject.CurrentQuantity += originallyQuantity;

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
        public static bool UpdateStockByExpiration()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Stocks
                         select item);

                    var dbObject = query.FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.CurrentQuantity = 0;

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
