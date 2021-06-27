using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    [Table("Movement")]
    public class Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DisplayName("Id")]
        [JsonProperty(PropertyName = "id")]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Rover")]
        [Column("rover_id")]
        [DisplayName("Rover Id")]
        [JsonProperty(PropertyName = "roverId")]
        [Required]
        public int RoverId { get; set; }

        [Column("value")]
        [DisplayName("Value")]
        [JsonProperty(PropertyName = "value")]
        [Required]
        public string value { get; set; }


        [Column("created")]
        [DisplayName("Created")]
        public DateTime Created { get; set; }
    }
}
