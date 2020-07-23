using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class PhysicalProductRule : IPaymentRule
    {
        
            
        public bool IsApplicable(Item item)
        {
            return item.ItemType==ItemType.PhysicalProduct;
        }

        public RuleLog Apply(Item item)
        {
           return new RuleLog{RuleName="Physical Product Rule" ,Activity="Package Slip generated for Shipping & Commission payment generated for Agent"};
        }
    }
}