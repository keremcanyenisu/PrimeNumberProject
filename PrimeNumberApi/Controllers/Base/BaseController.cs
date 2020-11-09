 
using Microsoft.AspNetCore.Mvc;
using PrimeNumberCore.Models;

namespace PrimeNumberApi.Controllers.Base
{
 
    public class BaseController : Controller
    {
        public override JsonResult Json(object data = null)
        {
            return new JsonResult(new BaseResponse (data));
        }
    }
}
