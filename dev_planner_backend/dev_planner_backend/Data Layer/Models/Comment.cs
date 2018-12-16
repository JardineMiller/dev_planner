using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace dev_planner_backend.Models
{
    public class Comment
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        
        public Person Author { get; set; }

        public DateTimeOffset PublishDate { get; set; }        
        
        public List<Comment> Replies { get; set; }

        [NotMapped]
        public List<int> ReplyIds
        {
            get { return this.Replies.Select(r => r.Id).ToList(); }
            set {}
        }

    }
}