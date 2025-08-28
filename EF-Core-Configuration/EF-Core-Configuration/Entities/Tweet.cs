using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Configuration.Entities
{
    [Table("tblTweets")]
    public class Tweet
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
