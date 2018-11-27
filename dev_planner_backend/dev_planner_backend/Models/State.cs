using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dev_planner_backend.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
