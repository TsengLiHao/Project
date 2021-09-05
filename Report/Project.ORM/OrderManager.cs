using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ORM
{
    public class OrderManager
    {
        public static List<Order> GetOrderListByAccount(string memberAccount)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Orders
                         where item.Account == memberAccount
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

        public static Order GetOrderInfoByAccount(string memberAccount)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Orders
                         where item.Account == memberAccount
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
        public static Order GetOrderInfo(int orderID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Orders
                         where item.OrderID == orderID
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

        public static List<Order> GetAllOrderList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Orders
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

        public static void CreateOrder(Order orderInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    
                    orderInfo.OrderDate = DateTime.Now;
                    context.Orders.Add(orderInfo);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateOrder(Order orderInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Orders.Where(obj => obj.OrderID == orderInfo.OrderID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.Account = orderInfo.Account;
                        dbObject.MemberName = orderInfo.MemberName;
                        dbObject.UnitPrice = orderInfo.UnitPrice;
                        dbObject.OrderedQuantity = orderInfo.OrderedQuantity;
                        dbObject.Payment = orderInfo.Payment;
                        dbObject.ProductName = orderInfo.ProductName;

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

        public static void DeleteOrder(int orderID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Orders.Where(obj => obj.OrderID == orderID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        context.Orders.Remove(dbObject);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
    }
}
