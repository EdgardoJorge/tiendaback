﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaData.Database.Tables
{
    [Table("categorias")]
    public class categoria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool state { get; set; }
    }
}
