using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VisaTrackingSystem.Models
{
    public class VisaDAL: AbstractVisaDAL
    {
        VisaTrackingSystemDBContext dbContext = new VisaTrackingSystemDBContext();
        
        public override IEnumerable<VisaDetails> GetAllVisa()
        {
            try
            {                
                return (dbContext.VisaDetails != null && dbContext.VisaDetails.Count() > 0) ? 
                            dbContext.VisaDetails.ToList() : Enumerable.Empty<VisaDetails>();                
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

        //Adding a new record        
        public override bool AddVisa(VisaDetails visaDetails)
        {
            try
            {
                if (visaDetails != null && visaDetails.VisaRequsitionId == 0)
                {
                    dbContext.VisaDetails.Add(visaDetails);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentException("Either Visadetails was null or the requistionId was not 0");                    
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //To Update the Visa record         
        public override bool UpdateVisa(VisaDetails updatedRecord)
        {
            try
            {
                if (updatedRecord.VisaRequsitionId != 0)
                {
                    VisaDetails trackedObj = find(dbContext, updatedRecord);
                    dbContext.VisaDetails.Remove(trackedObj);
                    dbContext.Entry(updatedRecord).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentException("The Updation is trying to happen for an visarequsitionId with 0");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //To get the record by VisaRequistionID        
        public override VisaDetails GetVisaById(int visaRequsitionId)
        {
            try
            {
                return visaRequsitionId != 0 ? find(dbContext, visaRequsitionId) : null; 
            }
            catch (ArgumentNullException ae)
            {
                throw ae;
            }
            catch (ArgumentException a)
            {
                throw a;
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        //To Delete the visa record        
        public override bool Delete(int visaRequsitionId)
        {
            try
            {
                if (visaRequsitionId != 0)
                {
                    VisaDetails visaDetails = find(dbContext, visaRequsitionId);
                    dbContext.VisaDetails.Remove(visaDetails);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentNullException("The VisaRequistionID was 0,so was not able to delete a record.");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public VisaDetails find(VisaTrackingSystemDBContext dbContext, VisaDetails visaDetails)
        {
            return dbContext.VisaDetails.Find(visaDetails.VisaRequsitionId);
        }
    }
}
