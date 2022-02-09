using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IServiceBusiness
    {
        int AddUpdateService(ServiceModel model);
        List<ServiceModel> GetAllServices();
        int ChangeStatus(int serviceId, bool status);
        List<UserServiceModel> GetUserServices(string userId);

        List<UserAllServiceModel> GetAllUserServices(string userId);
    }
}
