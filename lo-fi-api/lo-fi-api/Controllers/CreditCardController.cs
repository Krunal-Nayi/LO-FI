using lo_fi_api.BusinessLogic;
using lo_fi_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LO_FI_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CreditCardController : ControllerBase
    {
        private APIResponse _APIResponse;
        private ICreditCard _RCreditCard;

        public CreditCardController()
        {
            _RCreditCard = new RCreditCard();
        }

        /// <summary>
        /// Test call
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult TestAPI()
        {
            return Ok("API working fine");
        }

        /// <summary>
        /// Register the credit card details in system
        /// </summary>
        /// <param name="oCreditCard"></param>
        /// <returns></returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult RegisterCreditCard(CreditCard oCreditCard)
        {
            if (!ModelState.IsValid)
            {
                return Ok(oCreditCard);
            }

            _APIResponse = _RCreditCard.RegisterCreditCard(oCreditCard);

            return Ok(_APIResponse); ///Register Credit Card
        }

        /// <summary>
        /// Get all the credit card details
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllCreditCard(CreditCard oCreditCard)
        {
            if (oCreditCard == null)
                oCreditCard = new CreditCard();

            _APIResponse = _RCreditCard.FetchCreditCard(oCreditCard);

            return Ok(_APIResponse); ///Register Credit Card
        }

        /// <summary>
        /// Find or get only one credit card information based on filters
        /// </summary>
        /// <param name="oCreditCard"></param>
        /// <returns></returns>
        [Route("[action]")]
        [AcceptVerbs("HttpPost", "HttpGet")]
        public IActionResult FindCreditCard(CreditCard oCreditCard)
        {
            _APIResponse = _RCreditCard.FetchCreditCard(oCreditCard);

            return Ok(_APIResponse); ///Register Credit Card
        }
    }
}
