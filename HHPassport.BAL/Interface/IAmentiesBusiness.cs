using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IAmentiesBusiness
    {
        int AddUpdateAmenties(AmenitiesModel model);
        List<AmenitiesModel> GetAllAmenities();
        int ChangeStatus(int amenityId, bool status);
    }
}
