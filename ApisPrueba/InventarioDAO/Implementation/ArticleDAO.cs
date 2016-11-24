using System.Collections.Generic;
using System.Linq;

namespace InventarioDAO.Implementation
{
    public class ArticleDAO : Interface.IArticle
    {

        public void CreateArticle(InventarioDTO.Article elem)
        {
            new DB.PruebaEntities().usp_CreateArticle(elem.Description, elem.Price, elem.Total_in_shelf, elem.Total_in_vault, elem.Store_Id);
        }

        public void UpdateArticle(InventarioDTO.Article elem)
        {
            new DB.PruebaEntities().usp_UpdateArticle(elem.Article_Id, elem.Description, elem.Price, elem.Total_in_shelf, elem.Total_in_vault, elem.Store_Id);
        }

        public void DeleteArticle(long Article_Id)
        {
            new DB.PruebaEntities().usp_DeleteArticle(Article_Id);
        }

        public InventarioDTO.Results.ResultArticle ReadArticle(long Article_Id)
        {
            return GetArticles(Article_Id, null);
        }

        public InventarioDTO.Results.ResultArticle ReadArticles()
        {
            return GetArticles(null, null);
        }

        public InventarioDTO.Results.ResultArticle ReadArticleStore(long Store_Id)
        {
            return GetArticles(null, Store_Id);
        }

        private InventarioDTO.Results.ResultArticle GetArticles(long? id, long? Store_id)
        {
            InventarioDTO.Results.ResultArticle res = new InventarioDTO.Results.ResultArticle();
            try
            {
                res.articles = MapearTO(new DB.PruebaEntities().usp_ReadArticles(id, Store_id).ToList());
                res.success = true;
                res.total_elements = res.articles.Count();
            }
            catch (System.Exception ex)
            {
                res.success = false;
                res.error_msg = ex.Message;
            }

            return res;
        }

        private List<InventarioDTO.Article> MapearTO(IEnumerable<DB.usp_ReadArticles_Result> elem)
        {
            return (from art in elem
                    select new InventarioDTO.Article()
                    {
                        Article_Id = long.Parse(art.Article_Id.ToString()),
                        Description = art.Description,
                        Store_name = art.NameStore,
                        Price = System.Convert.ToInt64(art.Price.Value),
                        Store_Id = long.Parse(art.Store_Id.Value.ToString()),
                        Total_in_shelf = long.Parse(art.Total_in_shelf.ToString()),
                        Total_in_vault = long.Parse(art.Total_in_vault.ToString())
                    }).ToList();
        }
    }
}
