namespace ApiTest.Models.Request
{
    public class RequestSaleUpdate
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int inventarieId { get; set; }
        public int pieces { get; set; }
        public float totalPrice { get; set; }
    }
}
