using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ORM
{
    public class AdminManager
    {
        public static List<AdminInfo> GetAdminList(Guid adminID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.AdminInfoes
                         where item.AdminID == adminID
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

        public static AdminInfo GetAdminInfoByAccount(string adminAccount)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.AdminInfoes
                         where item.AdminAccount == adminAccount
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

        public static AdminInfo GetAdminInfoByID(Guid adminID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.AdminInfoes
                         where item.AdminID == adminID
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
        
        public static bool UpdateAdmin(AdminInfo adminInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.AdminInfoes.Where(obj => obj.AdminID == adminInfo.AdminID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.AdminAccount = adminInfo.AdminAccount;
                        dbObject.AdminName = adminInfo.AdminName;
                        dbObject.AdminPWD = adminInfo.AdminPWD;
                        dbObject.UserLevel = 0;

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

        public static void DeleteAdmin(Guid adminID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.AdminInfoes.Where(obj => obj.AdminID == adminID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        context.AdminInfoes.Remove(dbObject);
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
