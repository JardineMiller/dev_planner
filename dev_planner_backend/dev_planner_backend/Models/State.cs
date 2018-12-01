using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dev_planner_backend.Models
{
    /// <summary>
    /// Indicates the current state of a particular task.
    /// </summary>
    public class State
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the task
        /// </summary>
        [Required]
        public string Name { get; set; } 
    }
}
