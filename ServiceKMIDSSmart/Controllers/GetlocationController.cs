using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ServiceKMIDSSmart.Models;
using ServiceKMIDSSmart.Operation;

namespace ServiceKMIDSSmart.Controllers
{
    public class GetlocationController : ApiController
    {
        [HttpPost]
        public resGetlocationModel get(sendGetlocationModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.Get(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    public class GetloginController : ApiController
    {
        [HttpPost]
        public List<resgetloginModel> getlogin(SendSearchModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.getlogin(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class GetstudentregController : ApiController
    {
        [HttpPost]
        public List<resgetstudentregModel> getgetstudentreg(SendSearchModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.getgetstudentreg(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    public class SetinsertparentregisterController : ApiController
    {
        [HttpPost]
        public ressetinsertparentregisterModel set(List<SendsetinsertparentregisterModel> model)
        {
            try
            {
                var res = new ManagementData();
                return res.set(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class getstatusbusController : ApiController
    {
        [HttpPost]
        public resgetstatusbusModel get(SendgetstatusbusModel model)
        {
            try
            {
                var res = new ManagementData();
                return res.get(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
