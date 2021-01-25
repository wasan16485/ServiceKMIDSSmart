using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using ServiceKMIDSSmart.Models;

namespace ServiceKMIDSSmart.Operation
{
    public class ManagementData : config
    {
        public resGetlocationModel Get(sendGetlocationModel model)
        {
            var res = new resGetlocationModel();

            try
            {
                string latitudedb = "";
                string Longitudedb = "";
                using (var conn = DBconnect())
                {
               
                    string Query = "SELECT  latitude,Longitude,FixDistance FROM mas_location";
                    var ret = conn.Query<resDBGetlocationModel>(Query).ToList();
                    if (ret.Count > 0)
                    {
                        latitudedb = ret[0].latitude;
                        Longitudedb = ret[0].Longitude;
                        double EarthRadius = 6371e3;
                        double lat1 = double.Parse(latitudedb) * Math.PI / 180;
                        double lat2 = double.Parse(model.latitude) * Math.PI / 180;
                        //double lat3 = (lat2 - lat1) * Math.PI / 180;
                        double lon1 = (double.Parse(model.Longitude) - double.Parse(Longitudedb)) * Math.PI / 180;
                        // double A = Math.Pow(Math.Sin(lat3 / 2),2)  + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(lon1 / 2),2);
                        //double C = 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1- A));
                        double sum = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon1)) * EarthRadius;
                        res.Distance = Convert.ToInt32(sum);
                        res.FixDistance = ret[0].FixDistance; 
                    }

                    return res;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public List<resgetloginModel> getlogin(SendSearchModel model)
        {
            var res = new List<resgetloginModel>();
            try
            {
                using (var conn = DBconnect())
                {
                    string Query = "SELECT ops_mobile_user_menu.MobileMenuID, Menu , mas_mobile_user.MobileUserID, mas_mobile_user.Name FROM mas_mobile_user";
                    Query += " INNER JOIN ops_mobile_user_menu ON ops_mobile_user_menu.MobileUserID = mas_mobile_user.MobileUserID";
                    Query += " INNER JOIN mas_mobile_menu ON mas_mobile_menu.MobileMenuID = ops_mobile_user_menu.MobileMenuID";
                    Query += @" WHERE(Phone = " + model.Search + " OR IDcard = " + model.Search + ")";
                    Query += " AND ops_mobile_user_menu.IsActive = 1";
                    var ret = conn.Query<resgetloginModel>(Query).ToList();
                    if (ret.Count > 0)
                    {
                        foreach (var item in ret)
                        {
                            var list = new resgetloginModel();
                            list.MobileMenuID = item.MobileMenuID;
                            list.Menu = item.Menu;
                            list.MobileUserID = item.MobileUserID;
                            list.Name = item.Name;
                            res.Add(list);
                        }
                    }

                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<resgetstudentregModel> getgetstudentreg(SendSearchModel model)
        {
            var res = new List<resgetstudentregModel>();
            try
            {
                using (var conn = DBconnect())
                {
                    //string Query = "SELECT PersonID,case when TitleNameShort is not null then TitleNameShort";
                    //Query += " when titleNameShort is null then titleName END TitleName,FirstName,LastName,";
                    //Query += " FROM mas_mobile_user";
                    //Query += " INNER JOIN mas_mobile_student ON mas_mobile_student.MobileUserID = mas_mobile_user.MobileUserID";
                    //Query += " INNER JOIN mas_person ON mas_person.Code = mas_mobile_student.StudentCode";
                    //Query += " INNER JOIN mas_title ON mas_title.TitleID = mas_person.TitleID";          
                    //Query += @" WHERE(mas_mobile_user.Phone  = " + model.Search + " OR  mas_mobile_user.IDcard = " + model.Search + ")";
                    //Query += "AND mas_person.IsActive = 1 ";
                    string Query = "exec mobile_get_studentreg";
                           Query += "'" + model.Search + "'";
                    var ret = conn.Query<resgetstudentregModel>(Query).ToList();
                    if (ret.Count > 0)
                    {
                        foreach (var item in ret)
                        {
                            var list = new resgetstudentregModel();
                            list.PersonID = item.PersonID;
                            list.TitleName = item.TitleName;
                            list.FirstName = item.FirstName;
                            list.LastName = item.LastName;
                            list.StatusRegister = item.StatusRegister;
                            res.Add(list);
                        }
                    }

                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  ressetinsertparentregisterModel set(List<SendsetinsertparentregisterModel> model)
        {
            var res = new ressetinsertparentregisterModel();
            try
            {
                using (var conn = DBconnect())
                {
                    foreach (var item in model)
                    {                        
                        string Query = @"INSERT INTO ops_parent_register (PersonID,RegisterDate,IsRegisterType) VALUES (" + item.PersonID + ",getdate(),2)";
                       var  ret = conn.Query<ressetinsertparentregisterModel>(Query).FirstOrDefault();
                    }
            
                    }
                    return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public resgetstatusbusModel get(SendgetstatusbusModel model)
        {
            var res = new resgetstatusbusModel();
            try
            {
                using (var conn = DBconnect())
                {             
                    string Query = "exec mobile_get_statusbus";
                    Query += "'" + model.PersonID + "'";
                    var ret = conn.Query<resgetstatusbusModel>(Query).FirstOrDefault();
                    if (ret !=null)
                    {
                        res.TranscationBusID = ret.TranscationBusID;
                        res.UpDown = ret.UpDown;
                        res.UpDownName = ret.UpDownName;
                        res.result_status = ret.result_status;
                        res.result_status1 = ret.result_status1;
                    }

                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //-------------------------------------------------Checkbus------------------------------------------------------

        public List<resGetbusModel> getbus()
        {
            var res = new List<resGetbusModel>();
            try
            {
                using (var conn = DBconnect())
                {
                    string Query = "exec mobile_get_bus";
                    var ret = conn.Query<resGetbusModel>(Query).ToList();
                    if (ret.Count > 0)
                    {
                        foreach (var item in ret)
                        {
                            var list = new resGetbusModel();
                            list.BusID = item.BusID;
                            list.BusName = item.BusName;                     
                            res.Add(list);
                        }
                    }

                    return res;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<resGetbusdestinationModel> Getbusdestination(sendGetbusdestinationModel model)
        {
            var res = new List<resGetbusdestinationModel>();
            try
            {
                using (var conn = DBconnect())
                {
                    string Query = "exec mobile_get_busdestination";
                    Query += "'" + model.BusID + "'";
                    var ret = conn.Query<resGetbusdestinationModel>(Query).ToList();
                    if (ret.Count > 0)
                    {
                        foreach (var item in ret)
                        {
                            var list = new resGetbusdestinationModel();
                            list.BusDestinationID = item.BusDestinationID;
                            list.Destination = item.Destination;
                            list.TotalSeat = item.TotalSeat;
                            list.Latitude = item.Latitude;
                            list.Longitude = item.Longitude;
                            list.FixDistance = item.FixDistance;
                            res.Add(list);
                        }
                    }
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public resGetscaninbusModel  Getscaninbus(sendGetscaninbusModel model)
        {
            var res = new resGetscaninbusModel();
            try
            {
                using (var conn = DBconnect())
                {
                    string Query = "exec mobile_get_scaninbus";
                    Query += "'" + model.Code + "'";
                    Query += "," + model.BusDestinationID + "";
                    Query += "," + model.MobileUserID + "";
                    var ret = conn.Query<resGetscaninbusModel>(Query).FirstOrDefault();
                    if (ret != null)
                    {
                        res.PersonID = ret.PersonID;
                        res.Code = ret.Code;
                        res.Name = ret.Name;
                        res.Grade = ret.Grade;
                        res.Picture = ret.Picture;
                    }
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public resSetupdatestartjourneyModel setupdatestartjourney(sendSetupdatestartjourneyModel model)
        {
            var res = new resSetupdatestartjourneyModel();
            res.startjourney = new List<listSetupdatestartjourney>();
            try
            {
                using (var conn = DBconnect())
                {
                    conn.Open();
                    string str = "exec mobile_set_updatestartjourney ";
                    str += " " + model.MobileUserID + "";
                    var ret = conn.Query<DBresSetupdatestartjourneyModel>(str).ToList();
                    if (ret.Count > 0)
                    {
                        res.Total = ret[0].Total;     
                        foreach (var item in ret)
                        {
                            var list = new listSetupdatestartjourney();

                            list.Code = item.Code;
                            list.Name = item.Name;
                            list.Grade = item.Grade;
                            res.startjourney.Add(list);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }


        public resSetupdatearrivedestinationModel Setupdatearrivedestination(sendSetupdatearrivedestinationModel model)
        {
            var res = new resSetupdatearrivedestinationModel();
            try
            {
                using (var conn = DBconnect())
                {
                    string Query = "exec mobile_set_updatearrivedestination";
                    Query += "'" + model.MobileUserID + "'";          
                    var ret = conn.Query<resSetupdatearrivedestinationModel>(Query).FirstOrDefault();
                    if (ret != null)
                    {
                        res.Isstatus = ret.Isstatus;
                    }
                    else
                    {
                        res.Isstatus = "Fail";
                    }
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

