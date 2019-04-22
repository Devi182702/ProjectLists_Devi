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
        public IEnumerable<VisaDetails> Index() 
        {
            try
            {
                return dataAccessObj.GetAllVisa();
            }
            catch(ArgumentNullException ae)
            {
                throw ae;
            }
            catch (ArgumentException a)
            {
                throw a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("Get/{visaRequsitionID}")]
        public VisaDetails Get(int visaRequsitionID)
        {
            try
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
            catch(ArgumentNullException ae)
            {
                throw ae;
            }
            catch (ArgumentException a)
            {
                throw a;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // POST api/<controller>
        [HttpPost]
        [Route("Create")]
        [Consumes("application/json")]
        public bool Post([FromBody]VisaDetails visaDetails)
        {
            try
            {
                return dataAccessObj.AddVisa(visaDetails);
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
                
        // PUT api/<controller>/5
        [HttpPut]
        [Route("Update")]
        public bool Put([FromBody]VisaDetails visaDetails)
        {
            try
            {
                return dataAccessObj.UpdateVisa(visaDetails);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("Delete/{visaRequsitionId}")]
        public bool Delete(int visaRequsitionId)
        {
            try
            {
                return dataAccessObj.Delete(visaRequsitionId);
            }
            catch(ArgumentNullException a)
            {
                throw a;
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
