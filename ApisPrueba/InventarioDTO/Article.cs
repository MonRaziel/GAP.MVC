
namespace InventarioDTO
{
    public class Article
    {

        public long Article_Id { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long Total_in_shelf { get; set; }
        public long Total_in_vault { get; set; }
        public long Store_Id { get; set; }
        public string Store_name { get; set; }
    }
}
