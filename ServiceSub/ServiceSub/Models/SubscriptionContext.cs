using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ServiceSub.Models
{
    public class SubscriptionContext : DbContext
    {
        public SubscriptionContext()
            :base ("ServiceSub")
        {
        }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}