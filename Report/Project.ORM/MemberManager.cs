using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ORM
{
    public class MemberManager
    {
        public static List<MemberInfo> GetMemberList(Guid memberID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         where item.MemberID == memberID
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

        public static MemberInfo GetMemberInfoByAccount(string memberAccount)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
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
        #region CheckRepeat
        public static List<string>  GetMemberAccount()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         select item.Account).ToList();

                    var list = query;
                    return  list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static List<string> GetMemberName()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         select item.MemberName).ToList();

                    var list = query;
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static List<string> GetMemberEmail()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         select item.Email).ToList();

                    var list = query;
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static List<string> GetMemberPhone()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         select item.MobilePhone).ToList();

                    var list = query;
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static List<string> GetMemberAdess()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         select item.Adress).ToList();

                    var list = query;
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        #endregion

        #region CheckInfoForPWD
        public static string GetMemberInfoAccount(string memberAccount)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         where item.Account == memberAccount
                         select item.Account) ;

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
        #endregion
        public static void CreateMember(MemberInfo memberInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    memberInfo.MemberID = Guid.NewGuid();
                    memberInfo.CreateDate = DateTime.Now;
                    memberInfo.UserLevel = 1;
                    context.MemberInfoes.Add(memberInfo);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateMember(MemberInfo memberInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.MemberInfoes.Where(obj => obj.MemberID == memberInfo.MemberID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        dbObject.Account = memberInfo.Account;
                        dbObject.MemberName = memberInfo.MemberName;
                        dbObject.Email = memberInfo.Email;
                        dbObject.MobilePhone = memberInfo.MobilePhone;
                        dbObject.Adress = memberInfo.Adress;
                        dbObject.PWD = memberInfo.PWD;

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

        #region Admin
        public static List<MemberInfo> GetAllMemberList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
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

        public static MemberInfo GetMemberInfoByUserID(int memberUserID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.MemberInfoes
                         where item.UserID == memberUserID
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
        public static void DeleteMembr(int userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.MemberInfoes.Where(obj => obj.UserID == userID).FirstOrDefault();

                    if (dbObject != null)
                    {
                        context.MemberInfoes.Remove(dbObject);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        #endregion

    }

}
