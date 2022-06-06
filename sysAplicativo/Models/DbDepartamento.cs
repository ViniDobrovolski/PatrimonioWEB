using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SysAplicativo.Models
{
    [Table("departamento", Schema = "public")]
    public class DbDepartamento
    {
        [Key]
        public int id { get; set; }
        public string nomedepartamento { get; set; }
        public string descricaodepartamento { get; set; }
        
        public int idlocal { get; set; }    

        
    }
}