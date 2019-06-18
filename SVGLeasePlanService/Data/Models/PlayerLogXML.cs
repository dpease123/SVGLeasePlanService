namespace SVGLeasePlanService.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerLogXML")]
    public partial class PlayerLogXML
    {
        public int Id { get; set; }

        [Column(TypeName = "xml")]
        public string XMLData { get; set; }

        public DateTime? LoadedDateTime { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
