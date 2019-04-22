using System.Collections.Generic;

namespace VisaTrackingSystem.Models
{
    public abstract class AbstractVisaDAL : IVisaDAL
    {
        public abstract bool AddVisa(VisaDetails visaDetails);
        public abstract bool Delete(int visaRequsitionId);
        public abstract IEnumerable<VisaDetails> GetAllVisa();
        public abstract VisaDetails GetVisaById(int visaRequsitionId);
        public abstract bool UpdateVisa(VisaDetails visaDetails);            

        public VisaDetails find(VisaTrackingSystemDBContext dbContext, int visaRequsitionId)
        {
            return dbContext.VisaDetails.Find(visaRequsitionId);
        }
    }
}
