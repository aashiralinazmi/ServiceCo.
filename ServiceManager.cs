using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ServiceCo.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ServiceCo.Manager
{
    public class ServiceManager : GeneralManager
    {
        public bool AddService(ServiceModel Service)
        {
            tbl_service Data = new tbl_service()
            {
                FirstName = Service.FirstName,
                LastName = Service.LastName,
                Email = Service.Email,
                Contact = Service.Contact,
                Electrical = Service.Electrical,
                Sanitary = Service.Sanitary,
                Mechanical = Service.Mechanical,
                HouseCleansing = Service.HouseCleansing,
                Security = Service.Security,
                ChooseService = Service.ChooseService
            };
            ServDB.tbl_service.Add(Data);
            ServDB.SaveChanges();
            int ID = 0;
            ID = Data.FID;
            if (ID > 0)           
                return true;           
            else          
                return false;            
        }
        public List<ServiceModel> GetAllService()
        {
            var Data = ServDB.tbl_service.ToList();
            List<ServiceModel> Services = Data.Select(x => new ServiceModel() { FID = x.FID, FirstName = x.FirstName, LastName = x.LastName, Email = x.Email, Contact = x.Contact, Electrical = x.Electrical, Sanitary = x.Sanitary, Mechanical = x.Mechanical, HouseCleansing = x.HouseCleansing, Security = x.Security, ChooseService = x.ChooseService }).ToList();
            return Services;
        }

        public ServiceModel GetService(int FID)
        {
            var Data = ServDB.tbl_service.Where(x => x.FID == FID).FirstOrDefault();
            ServiceModel Service = new ServiceModel()
            {
                FID = Data.FID,
                FirstName = Data.FirstName,
                LastName = Data.LastName,
                Email = Data.Email,
                Contact = Data.Contact,
                Electrical = Data.Electrical,
                Sanitary = Data.Sanitary,
                Mechanical = Data.Mechanical,
                HouseCleansing = Data.HouseCleansing,
                Security = Data.Security,
                ChooseService = Data.ChooseService

            };
            return Service;
        }

        public bool UpdateService(ServiceModel Service)
        {
            tbl_service Data = ServDB.tbl_service.Where(x => x.FID == Service.FID).FirstOrDefault();
            bool check = false;
            if (Data != null)
            {
                Data.FID = Service.FID;
                Data.FirstName = Service.FirstName;
                Data.LastName = Service.LastName;
                Data.Email = Service.Email;
                Data.Contact = Service.Contact;
                Data.Electrical = Service.Electrical;
                Data.Sanitary = Service.Sanitary;
                Data.Mechanical = Service.Mechanical;
                Data.HouseCleansing = Service.HouseCleansing;
                Data.Security = Service.Security;
                Data.ChooseService = Service.ChooseService;

                ServDB.Entry(Data).State = EntityState.Modified;
                ServDB.SaveChanges();
                check = true;
            }
            return check;
        }
        public bool DeleteService(int FID)
        {
            tbl_service Data = ServDB.tbl_service.Where(x => x.FID == FID).FirstOrDefault();
            bool check = false;
            if (Data != null)
            {
                ServDB.Entry(Data).State = EntityState.Deleted;
                ServDB.SaveChanges();
                check = true;
            }
            return check;
        }
    }
}