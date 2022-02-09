using HH_PassportModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.BAL.Interface
{
    public interface IIntegratorBusiness 
    {
        LoginResponseModel tenant(TenantResponseModel tenantModel,string env,string token);
        ResponseModel<string> UpdateTenant(string id,TenantResponseModel tenantModel, string env);
        //LoginResponseModel GetIntegrator(tenantLoginModel loginModel);
        ResponseModel<string> verify_email(String email, string env);
        ResponseModel<FindByEmailModel> find_by_email(string email,string env,string token);
        ResponseModel<PedDetails> TenantPDF(string id,string env);

        //int AddUpdateIntegrator(IntegratorModel model);
        int AddUpdateIntegrator(IntegratorModel model);
        List<IntegratorModel> GetIntegratorList(int id);
        ResponseModel<PedDetails> Tenant_PedDetails(string id, string env);
        ResponseModel<PaymentInfo> GetTenantBalance(string id, string env);


        int UploadDocuments(TenantDocumentModel obj, string id);

        List<docs> GetDocuments(string id);

        bool GetValidateRefNumber(string id, string refno);

        ResponseModel<string> CreateUpdateCosigner(string id, CosignerInfo cosignerObj, string env);

    }
}
