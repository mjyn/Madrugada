using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public bool IsReply { get; set; }
        public bool IsAnonymous { get; set; }
        public string UserId { get; set; }

        public int? ReplyId { get; set; }
        [ForeignKey("ReplyId")]
        public Message ReplyMessage { get; set; }

        public bool IsIPv6 { get; set; }
        public string IPAddress { get; set; }
    }
}
