using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.BAL.Interface
{
    public interface IPropertiesBusiness
    {
        int AddUpdateProperties(PropertyModel model);

        int AddUpdateSearchPropertiesCriteria(PropertySearchModel model);
        List<PropertyModel> GetAllAgentProperties(int id, string agentId);
        int ChangeStatus(int id, bool status);
        List<AgentPropertiesSerachResponseVM> GetAgentPropertiesListBySearchParams(string destinationLatitude, string destinationLongitude, string locationFar, string Interval, decimal budgetFrom, decimal budgetTo, int noOfRooms, string furnishedType, string amentyIds, string agentId);
        PropertySearchModel GetHFSSearchHistory(string userId);
        int SaveAgentLead(string applicantId, string agentId);
        int AgencyClicked(string applicantId, string agentId);

        int DeleteAgentLead(string applicantId);
        int ChangeAgentLeadStatus(string applicantId, string agentId, char status);
        List<AgentResponseLeadModel> GetAgentLeads(string agentId, char status = 'N');
        int AddUpdateAgentPreferences(AgentPreferencesModel model);
        AgentPreferencesModel GetAgentPreferences(string agentId);
        int ConvertedToCustomer(ConvertedCustomerModel obj);

        List<AgentHfsPrefernceModel> GetAgentByPreference(string destinationLatitude, string destinationLongitude, string locationFar, string Interval, decimal budgetFrom, decimal budgetTo, int noOfRooms, string furnishedType, string amentyIds);

        AgentStatsModel GetAgentStats(string agentId);

        int UpdateCosignerById(GurantorCosignerVM cosignerObj);
    }
}
