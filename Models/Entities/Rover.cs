using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    [Table("Rover")]
    public class Rover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DisplayName("Id")]
        [JsonProperty(PropertyName = "id")]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Grid")]
        [Column("grid_id")]
        [DisplayName("Grid Id")]
        [JsonProperty(PropertyName = "gridId")]
        [Required]
        public int GridId { get; set; }

        [ForeignKey("Point")]
        [Column("point_id")]
        [DisplayName("Point Id")]
        [JsonProperty(PropertyName = "pointId")]
        [Required]
        public int PointId { get; set; }
        
        [Column("heading_degree")]
        [DisplayName("Heading Degree")]
        public int HeadingDegree { get; set; }

        [Column("created")]
        [DisplayName("Created")]
        public DateTime Created { get; set; }

        public virtual Grid Grid { get; set; }
        public virtual Point Point { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }

    }
}
