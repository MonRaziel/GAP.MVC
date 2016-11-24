using ApisPrueba.Attributes;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;


namespace ApisPrueba.Controllers
{
    [WebApiAuthorizeFilterAttribute]
    public class articlesController : ApiController
    {
        /// <summary>
        /// Se obtienen todos los registros de la base de datos
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Ok(new InventarioDAO.Implementation.ArticleDAO().ReadArticles());
        }

        /// <summary>
        /// Se obtiene un registro especifico 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(long id)
        {
            return Ok(new InventarioDAO.Implementation.ArticleDAO().ReadArticle(id));
        }

        [HttpGet]
        [ResponseType(typeof(InventarioDTO.Results.ResultArticle))]
        [Route("services/articles/stores/{id}")]
        public IHttpActionResult stores(long id)
        {
            var resArticle = new InventarioDAO.Implementation.ArticleDAO().ReadArticleStore(id);

            if (resArticle.total_elements > 0)
                return Ok(resArticle);
            else
                return NotFound();
        }

        /// <summary>
        /// Se crea un nuevo registro
        /// </summary>
        /// <param name="elem"></param>
        public IHttpActionResult Post(InventarioDTO.Article elem)
        {
            new InventarioDAO.Implementation.ArticleDAO().CreateArticle(elem);
            return Ok();
        }

        /// <summary>
        /// Se actualiza un nuevo registro
        /// </summary>
        /// <param name="elem"></param>
        public IHttpActionResult Put(InventarioDTO.Article elem)
        {
            new InventarioDAO.Implementation.ArticleDAO().UpdateArticle(elem);
            return Ok();
        }

        /// <summary>
        /// Se eimina un registro
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult Delete(long id)
        {
            new InventarioDAO.Implementation.ArticleDAO().DeleteArticle(id);
            return Ok();
        }
    }
}
