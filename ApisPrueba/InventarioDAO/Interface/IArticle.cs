using System.Collections.Generic;

namespace InventarioDAO.Interface
{
    public interface IArticle
    {
        void CreateArticle(InventarioDTO.Article elem);
        void UpdateArticle(InventarioDTO.Article elem);
        void DeleteArticle(long Article_Id);
        InventarioDTO.Results.ResultArticle ReadArticle(long Article_Id);
        InventarioDTO.Results.ResultArticle ReadArticles();
    }
}
