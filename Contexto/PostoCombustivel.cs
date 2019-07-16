namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostoCombustivel")]
    public partial class PostoCombustivel
    {
        [Key]
        public int PostoCombustivelId { get; set; }

        public int PostoId { get; set; }

        public int CombustivelId { get; set; }
        public decimal Preco { get; set; }

        public virtual Combustivel Combustivel { get; set; }

        public virtual Posto Posto { get; set; }
    }
}
