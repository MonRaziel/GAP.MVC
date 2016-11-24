using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ApisPrueba.Attributes
{
    public class WebApiAuthorizeFilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Se obtienen las credenciales válidas para autenticarse en el servicio y se codifican en base64, 
            // para compararlas con las que envía el cliente ya que estas se reciben en base64.
            var credencialesServicio =
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        $"{ConfigurationManager.AppSettings.Get("UsuarioApis")}:{ConfigurationManager.AppSettings.Get("ClaveApis")}"));

            if (actionContext.Request.Headers.Authorization != null)
            {
                if (!credencialesServicio.Equals(actionContext.Request.Headers.Authorization.Parameter))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}