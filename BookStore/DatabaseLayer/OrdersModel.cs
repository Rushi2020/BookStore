using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer
{
    public class OrdersModel
    {
        public int OrdersId { get; set; }
        public int id { get; set; }
        public int AddressId { get; set; }
        public int BookId { get; set; }
        //public int DiscountPrice { get; set; }
        public int BookQuantity { get; set; }
        public DateTime Order_Date { get; set; }
        public string OrderPlaced { get; set; }
    }
}
