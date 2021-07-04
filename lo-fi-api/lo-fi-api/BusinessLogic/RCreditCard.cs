using lo_fi_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lo_fi_api.BusinessLogic
{
    public class RCreditCard : ICreditCard
    {
        private APIResponse _ResponseModel;

        /// <summary>
        /// Store Credit card information in the Database
        /// </summary>
        /// <param name="oCreditCard"></param>
        /// <returns></returns>
        public APIResponse RegisterCreditCard(CreditCard oCreditCard)
        {
            _ResponseModel = validateCreditCardModel(oCreditCard);

            if (_ResponseModel.StatusCode != 2000)
            {
                return _ResponseModel;
            }

            /// Note:::
            /// Logic for the store credit card information into the Database
            ///
            /// I'm keeping off now because DB setup is depends on Business requirements.
            ///

            return _ResponseModel;
        }

        /// <summary>
        /// Fetch Credit card information based upon the filters applied in model
        /// </summary>
        /// <param name="oCreditCard"></param>
        /// <returns></returns>
        public APIResponse FetchCreditCard(CreditCard oCreditCard)
        {
            _ResponseModel = validateCreditCardModel(oCreditCard);

            //Validate model for the filter apply only
            if (_ResponseModel.StatusCode == 2000)
            {
                /// Fetch credit card information filter by the model values [Select only one]
                /// 
                _ResponseModel.CreditCard = oCreditCard; //Suppose single object return
            }
            else
            {
                /// Featch all the credit card information from the DB no filter choose at the moment
                /// Keep simple filter for select all
                /// 
                _ResponseModel.CreditCards = new List<CreditCard>(); //Suppose the list of credit card infor getting form the DB
            }

            return _ResponseModel;
        }

        /// <summary>
        /// Validate the credit card information for user
        /// </summary>
        /// <param name="oCreditCard"></param>
        /// <returns></returns>
        public APIResponse validateCreditCardModel(CreditCard oCreditCard)
        {
            _ResponseModel = new APIResponse();
            bool bIsValidCreditcard = true;

            if (string.IsNullOrEmpty(oCreditCard.UserName))
            {
                _ResponseModel.StatusCode = 5001;
                _ResponseModel.Message = "User Name is required.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

            if (string.IsNullOrEmpty(oCreditCard.CreditCardNumber))
            {
                _ResponseModel.StatusCode = 5002;
                _ResponseModel.Message = "Credit Card is required.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

            if (oCreditCard.CreditCardNumber.Length < 12 || oCreditCard.CreditCardNumber.Length > 16 || !CheckValidCreditCard(oCreditCard.CreditCardNumber))
            {
                _ResponseModel.StatusCode = 5003;
                _ResponseModel.Message = "Credit Card is not valid.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

            if (string.IsNullOrEmpty(oCreditCard.CVC))
            {
                _ResponseModel.StatusCode = 5004;
                _ResponseModel.Message = "CVC is required.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

            if (oCreditCard.CVC.Length != 3 || !oCreditCard.CVC.All(char.IsDigit))
            {
                _ResponseModel.StatusCode = 5005;
                _ResponseModel.Message = "CVC is not valid.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

            if (!(oCreditCard.ExpiryDate > DateTime.Today))
            {
                _ResponseModel.StatusCode = 5006;
                _ResponseModel.Message = "Expiry Date is not valid.";
                bIsValidCreditcard = false;
                goto invalidCreditCardInfo;
            }

        invalidCreditCardInfo:
            if (bIsValidCreditcard)
            {
                _ResponseModel.StatusCode = 2000;
                _ResponseModel.Message = "All information is valid.";
            }

            _ResponseModel.CreditCard = oCreditCard;
            return _ResponseModel;
        }

        /// <summary>
        /// Credit card validation through Luhn formula
        /// </summary>
        /// <param name="sCreditCardNumber"></param>
        /// <returns></returns>
        public bool CheckValidCreditCard(string sCreditCardNumber)
        {
            return sCreditCardNumber.All(char.IsDigit) && sCreditCardNumber.Reverse()
                .Select(c => c - 48)
                .Select((iThisNum, i) => i % 2 == 0
                    ? iThisNum
                    : ((iThisNum *= 2) > 9 ? iThisNum - 9 : iThisNum)
                ).Sum() % 10 == 0;
        }
    }
}
