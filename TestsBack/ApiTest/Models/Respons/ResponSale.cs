namespace ApiTest.Models.Respons
{
    public class ResponSale
    {
        public int? id { get; set; }
        public int? clientId { get; set; }
        public string? client { get; set; }
        public int? inventarieId { get; set; }
        public int? articleId { get; set; }
        public string? article { get; set; }
        public int? pieces { get; set; }
        public float? totalPrice { get; set; }
        public float? unitPrice { get; set; }
    }
}
