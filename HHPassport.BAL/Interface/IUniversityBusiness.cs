using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IUniversityBusiness
    {
        int AddUpdateUniversity(UniversityModel model);
        List<UniversityModel> GetAllUniversites(int id);
        List<UniversityModel> GetAllUniversitesFrontEnd(int id);

        int ChangeStatus(int id, bool status);
    }
}
