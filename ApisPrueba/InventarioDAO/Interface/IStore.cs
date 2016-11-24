using System.Collections.Generic;

namespace InventarioDAO.Interface
{
    public interface IStore
    {
        void CreateStore(InventarioDTO.Store elem);
        void UpdateStore(InventarioDTO.Store elem);
        void DeleteStore(long Store_Id);
        InventarioDTO.Results.ResultStore ReadStores();
        InventarioDTO.Results.ResultStore ReadStore(long Store_Id);
    }
}
