using lo_fi_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lo_fi_api.BusinessLogic
{
    public interface ICreditCard
    {
        #region Save Information
        APIResponse RegisterCreditCard(CreditCard oCreditCard);
        APIResponse FetchCreditCard(CreditCard oCreditCard);
        #endregion
    }
}
