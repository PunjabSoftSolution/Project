using NumberToWords.Core.Interfaces;
using NumberToWords.Core.Utility;
using NumberToWords.DTO;
using NumberToWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NumberToWords.Controllers
{
    public class ManageNumberController : ApiController
    {
        private readonly IManageNumberRepository _manageNumberRepository;

        public ManageNumberController(IManageNumberRepository manageNumberRepository)
        {
            _manageNumberRepository = manageNumberRepository;
        }


        [HttpPost]
        [Route("api/ManageNumber/ConvertToWords")]
        public Result<string> ConvertToWords(ManageNumberDTO value)
        {
            string result = string.Empty;
            string number = Convert.ToString(value.Number);

            try
            {
                if (number.Contains("."))
                {
                    result = _manageNumberRepository.ConvertToWords(Convert.ToInt32(number.Split('.').FirstOrDefault()));
                    result += " " + Constants.DOLLARS;
                    if (!string.IsNullOrEmpty(number.Split('.').LastOrDefault()))
                    {
                        result += " " + Constants.AND + " ";
                        result += _manageNumberRepository.ConvertToWords(Convert.ToInt32(number.Split('.').LastOrDefault()));
                        result += " " + Constants.CENT + " ";
                    }
                }
                else
                {
                    result = _manageNumberRepository.ConvertToWords((int)value.Number);
                    result += Constants.DOLLARS;
                }

                return new Result<string>(value.Name +": " + result, "", "");
            }
            catch (Exception ex)
            {
                // Manage log here 
                return new Result<string>("", "Getting some error", "");
            }
        }
    }
}