using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepApiBank.Models
{
    public class TransactionHistory
    {
        public string Id { get; set; }
        public string TransactionCount { get; set; }
        public string TransactionAmount { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}