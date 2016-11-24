using System.Collections.Generic;
using System.Linq;

namespace InventarioDAO.Implementation
{
    public class StoreDAO : Interface.IStore
    {
        public void CreateStore(InventarioDTO.Store elem)
        {
            new DB.PruebaEntities().usp_CreateStore(elem.Name, elem.Address);
        }

        public void UpdateStore(InventarioDTO.Store elem)
        {
            new DB.PruebaEntities().usp_UpdateStore(elem.Store_Id, elem.Name, elem.Address);
        }

        public void DeleteStore(long Store_Id)
        {
            new DB.PruebaEntities().usp_DeleteStore(Store_Id);
        }

        public InventarioDTO.Results.ResultStore ReadStores()
        {
            return GetStores(null);
        }

        public InventarioDTO.Results.ResultStore ReadStore(long Store_Id)
        {
            return GetStores(Store_Id);
        }

        private InventarioDTO.Results.ResultStore GetStores(long? id)
        {
            InventarioDTO.Results.ResultStore res = new InventarioDTO.Results.ResultStore();
            try
            {
                res.stores = MapearTO(new DB.PruebaEntities().usp_ReadStore(id));
                res.success = true;
                res.total_elements = res.stores.Count();
            }
            catch (System.Exception ex)
            {
                res.success = false;
                res.error_msg = ex.Message;
            }

            return res;
        }

        private List<InventarioDTO.Store> MapearTO(IEnumerable<DB.usp_ReadStore_Result> elem)
        {
            return (from art in elem
                    select new InventarioDTO.Store()
                    {
                        Store_Id = long.Parse(art.Store_Id.ToString()),
                        Name = art.Name,
                        Address = art.Address,
                    }).ToList();
        }
    }
}
