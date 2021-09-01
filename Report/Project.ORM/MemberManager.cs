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
        #endregion

    }

}
