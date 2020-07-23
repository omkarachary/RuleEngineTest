using System;
using System.Collections.Generic;

namespace RuleEngine.Entity
{
    public class Payment:BaseEntity
    {
        public String  Name { get; set; }

        public IList<Item> Items{ get; set; }

    }
}