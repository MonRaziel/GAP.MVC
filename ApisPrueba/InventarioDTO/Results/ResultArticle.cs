using System.Collections.Generic;

namespace InventarioDTO.Results
{
    public class ResultArticle : GenericResult
    {
        public List<Article> articles { get; set; }
    }
}
