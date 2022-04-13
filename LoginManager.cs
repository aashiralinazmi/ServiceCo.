using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceCo.Models;

namespace ServiceCo.Manager
{
    public class LoginManager:GeneralManager
    {
        public ServiceModel CheckLogin(LoginModel LoginData)
        {
            var Data = ServDB.tbl_login.Where(x => x.UserName == LoginData.UserName && x.UserPassword == LoginData.UserPassword).FirstOrDefault();
            ServiceModel ServiceData = null;
            if (Data!=null)
            {
                var Data2 = ServDB.tbl_service.Where(x => x.FID == Data.FID).FirstOrDefault();
                ServiceData = new ServiceModel()
                {
                    FirstName = Data2.FirstName,
                    LastName = Data2.LastName,
                    FID = Data2.FID,
                    LoginInfo = new LoginModel() { LoginID = Data.LoginID, UserName = Data.UserName, UserPassword = Data.UserPassword, Role = Data.Role }

                };
                
            }
            return ServiceData;
        }
    }
}