using System.Collections.Generic;

namespace VisaTrackingSystem.Models
{
    public interface IVisaDAL
    {
        IEnumerable<VisaDetails> GetAllVisa();
        bool AddVisa(VisaDetails visaDetails);
        bool UpdateVisa(VisaDetails visaDetails);
        VisaDetails GetVisaById(int visaRequsitionId);
        bool Delete(int visaRequsitionId);        
    }
}
