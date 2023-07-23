﻿namespace CQRS_Casgem.CQRSPattern.Comments
{
    public class CreateProductCommand
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}
