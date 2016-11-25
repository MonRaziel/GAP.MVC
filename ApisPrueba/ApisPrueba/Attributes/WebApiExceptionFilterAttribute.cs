using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ApisPrueba.Attributes
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Sobreescribe el método para controlar las excepciones que se generan desde los web api controllers de la capa de servicios api.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var excepcion = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(context.Exception.StackTrace),
                ReasonPhrase = context.Exception.Message
            };

            var controllerName = context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = context.ActionContext.ActionDescriptor.ActionName;

            //Manejar log en archivos o en bd

            context.Response = excepcion;
        }
    }
}