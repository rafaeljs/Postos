namespace Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Combustivel")]
    public partial class Combustivel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Combustivel()
        {
            PostoCombustivel = new HashSet<PostoCombustivel>();
        }

        [Key]
        public int CombustivelId { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime DataInclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostoCombustivel> PostoCombustivel { get; set; }
    }
}
