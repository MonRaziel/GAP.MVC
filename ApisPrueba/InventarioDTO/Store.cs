using System.Collections.Generic;

namespace InventarioDTO
{
    public class Store
    {
        public long Store_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Article> lstArticles { get; set; }
    }
}
