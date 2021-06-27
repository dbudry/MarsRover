using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    [Table("Points")]
    public class Point
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DisplayName("Id")]
        [JsonProperty(PropertyName = "id")]
        [Required]
        public int Id { get; set; }

        [Column("north")]
        [DisplayName("North")]
        public int North { get; set; }

        [Column("east")]
        [DisplayName("East")]
        public int East { get; set; }

        [Column("south")]
        [DisplayName("South")]
        public int South { get; } = 0;

        [Column("west")]
        [DisplayName("West")]
        public int West { get; } = 0;
    }
}
