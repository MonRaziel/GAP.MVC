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

            string innerExp = string.Empty;
            if (context.Exception.InnerException != null)
            {
                innerExp = context.Exception.InnerException.Message;
            }
            var excepcion = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(string.Format("{0} - {1}", context.Exception.StackTrace, innerExp)),
                ReasonPhrase = context.Exception.Message
            };

            var controllerName = context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = context.ActionContext.ActionDescriptor.ActionName;

            //Manejar log en archivos o en bd

            context.Response = excepcion;
        }
    }
}