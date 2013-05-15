using System.Web.Http;
using System.Net.Http;

namespace iDDD.IssueTracker.Web.Controllers
{
    public class RoleController : ApiController
    {
        public HttpResponseMessage Get(string tenantId, string userId, string roleName)
         {
             return Request.CreateResponse();
         }
    }
}