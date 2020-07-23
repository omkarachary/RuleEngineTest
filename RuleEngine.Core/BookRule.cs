using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class BookRule : IPaymentRule
    {
        

        public bool IsApplicable(Item item)
        {
            return item.ItemType==ItemType.Book;
        }

        public RuleLog Apply(Item item)
        {
             return new RuleLog{RuleName="Book Rule" ,Activity="Duplicate Slip generated for Royalty Dept & Commission payment generated for Agent"};
        }
    }
}