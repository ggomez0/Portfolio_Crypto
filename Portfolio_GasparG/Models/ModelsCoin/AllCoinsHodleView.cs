using System;
namespace Portfolio_GasparG.Models.ModelsCoin
{
    public class AllCoinsHodleView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string imagelocation { get; set; }
        public decimal Total { get; set; }
        public decimal Price { get; set; }
    }
}
