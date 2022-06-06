using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SysAplicativo.Models
{
    [Table("categoria", Schema = "public")]
    public class DbCategoria
    {
        [Key]
        public int id { get; set; }
        public string descricaocategoria { get; set; }


    }
}