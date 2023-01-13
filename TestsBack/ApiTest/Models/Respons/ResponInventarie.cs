namespace ApiTest.Models.Respons
{
    public class ResponInventarie
    {
        public int id { get; set; }
        public int? articleId { get; set; }
        public string? articleDesciption { get; set; }
        public int? storeId { get; set; }
        public int? stock { get; set; }
        public float? price { get; set; }
        public string? image{ get; set; }
    }
}
