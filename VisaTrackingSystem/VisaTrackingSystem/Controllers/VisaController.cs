using System.Collections.Generic;
using VisaTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace VisaTrackingSystem.Controllers
{
    [Route("api/VisaDetails/")]
    public class VisaController : ControllerBase
    {
        IVisaDAL dataAccessObj = null;

        public VisaController(IVisaDAL visaDAL)
        {
            this.dataAccessObj = visaDAL;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("Index")]
        [Produces("application/json")]
        public IEnumerable<VisaDetails> Index() 
        {
            this.ControllerContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return dataAccessObj.GetAllVisa();
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("Get/{visaRequsitionID}")]
        public VisaDetails Get(int visaRequsitionID)
        {
            if (visaRequsitionID != 0)
            {
                var visaDetail = dataAccessObj.GetVisaById(visaRequsitionID);
                if (visaDetail == null)
                {
                    throw new Exception("Was not able to retrive the record for the given ID:" + visaRequsitionID);
                }
                return visaDetail;
            }
            else
            {
                throw new ArgumentNullException("VisaRequsitionID cannot be 0 while Get Call.");
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("Create")]
        [Consumes("application/json")]
        public bool Post([FromBody]VisaDetails visaDetails)
        {
            return dataAccessObj.AddVisa(visaDetails);           
        }
                
        // PUT api/<controller>/5
        [HttpPut]
        [Route("Update")]
        public bool Put([FromBody]VisaDetails visaDetails)
        {
             return dataAccessObj.UpdateVisa(visaDetails);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("Delete/{visaRequsitionId}")]
        public bool Delete(int visaRequsitionId)
        {
            return dataAccessObj.Delete(visaRequsitionId);
        }
    }
}
