using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitites.Concrete
{
    public class Product : IEntity
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("units_in_stock")]
        public short UnitInStock { get; set; }

        [Column("unit_price")]
        public float UnitPrice { get; set; }
    }
}
