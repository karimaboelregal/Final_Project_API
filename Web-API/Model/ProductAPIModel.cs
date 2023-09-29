namespace Web_API.Model
{
    public class ProductAPIModel
    {
        public Guid Id { get; set; }       
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        //public string Image { get; set; }
        public Guid CategoryId { get; set; }
    }
}
