using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dev_planner_backend.Models
{
    /// <summary>
    /// A person is a user of the application. A person can own and amend tasks, as well as creating new ones.
    /// </summary>
    public class Person
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the person
        /// </summary>
        [Required] [MaxLength(50)]
        public string Name { get; set; }
        
        /// <summary>
        /// Email fo the person
        /// </summary>
        [Required] [MaxLength(100)]
        public string Email { get; set; }
        
    }
}
