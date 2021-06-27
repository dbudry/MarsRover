using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarsRover.Models
{
    public class HomeViewModel
    {
        [Required]
        [RegularExpression(@"^([0-9]+[/\s]+[0-9])$", ErrorMessage = "Please use two integers seperated by a space.")]
        [Display(Name = "Grid Boundry")]
        public string GridBounds { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]+[/\s]+[0-9]+[/\s]+[NESWnesw])$", ErrorMessage = "Please use two integers seperated by a space then followed by a space then direction (N,E,S,W).")]
        [Display(Name = "Rover Location")]
        public string RoverBounds { get; set; }

        [Required]
        [RegularExpression(@"^([LRMlrm]+)$", ErrorMessage = "Please provid direction (L or R) and movements (M) with no spaces.")]
        [Display(Name = "Rover Movements")]
        public string RoverMovement { get; set; }

        public List<String> RoverPositions { get; set; }

        public HomeViewModel()
        {
            RoverPositions = new List<string>();
        }
    }
}
