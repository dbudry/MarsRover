using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    [Table("Grid")]
    public partial class Grid
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DisplayName("Id")]
        [JsonProperty(PropertyName = "id")]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Point")]
        [Column("point_id")]
        [DisplayName("Point Id")]
        [JsonProperty(PropertyName = "pointId")]
        [Required]
        public int PointId { get; set; }

        public virtual Point Point { get; set; }
        public virtual ICollection<Rover> Rovers { get; set; }
    }
}
