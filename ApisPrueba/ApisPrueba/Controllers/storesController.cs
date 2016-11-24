using ApisPrueba.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace ApisPrueba.Controllers
{
    [WebApiAuthorizeFilterAttribute]
    public class storesController : ApiController
    {
        /// <summary>
        /// Se obtienen todos los registros de la base de datos
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Ok(new InventarioDAO.Implementation.StoreDAO().ReadStores());
        }

        /// <summary>
        /// Se obtiene un registro especifico 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(long id)
        {
            return Ok(new InventarioDAO.Implementation.StoreDAO().ReadStore(id));
        }

        /// <summary>
        /// Se crea un nuevo registro
        /// </summary>
        /// <param name="elem"></param>
        public IHttpActionResult Post(InventarioDTO.Store elem)
        {
            new InventarioDAO.Implementation.StoreDAO().CreateStore(elem);
            return Ok();
        }

        /// <summary>
        /// Se actualiza un nuevo registro
        /// </summary>
        /// <param name="elem"></param>
        public IHttpActionResult Put(InventarioDTO.Store elem)
        {
            new InventarioDAO.Implementation.StoreDAO().UpdateStore(elem);
            return Ok();
        }

        /// <summary>
        /// Se eimina un registro
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult Delete(long id)
        {
            new InventarioDAO.Implementation.StoreDAO().DeleteStore(id);
            return Ok();
        }
    }
}
