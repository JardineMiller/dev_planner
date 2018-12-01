using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Newtonsoft.Json;

namespace dev_planner_backend.Models
{
    /// <summary>
    /// An item is a task on the to do list. It can be in various states and can be owned by a Person.
    /// </summary>
    public class Item
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// The id of the current of the item
        /// </summary>
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }

        /// <summary>
        /// The current state of the item
        /// </summary>
        [JsonIgnore]
        public State State { get; set; }
        
        
        /// <summary>
        /// The id of the current owner of the item
        /// </summary>
        [ForeignKey("Owner")]
        public int? PersonId { get; set; }
        
        /// <summary>
        /// The current owner if the item
        /// </summary>
        [JsonIgnore]
        public Person Owner { get; set; }
    }
}
