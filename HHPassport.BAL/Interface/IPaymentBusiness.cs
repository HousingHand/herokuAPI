using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.BAL.Interface
{
    public interface IPaymentBusiness
    {
        int AddUpdatePaymentInfo(PaymentInfoModel model);
    }
}
