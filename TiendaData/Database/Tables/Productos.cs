using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaData.Database.Tables
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [StringLength (50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public SqlMoney price { get; set; }
        public int quantity { get; set; }
        public DateTime expirationDate { get; set; }
        public int lote {  get; set; }
        public int id_categoria { get; set; }
    }
}
