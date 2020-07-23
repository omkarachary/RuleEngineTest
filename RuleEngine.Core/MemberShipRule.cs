using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class MemberShipRule : IPaymentRule
    {
        public RuleLog Apply(Item item)
        {
            return new RuleLog{RuleName="Membership Rule" ,Activity="Membership Activated & Informed Owner of Activation"};

        }

        public bool IsApplicable(Item item)
        {
           return item.ItemType==ItemType.MemberShip;
        }
    }
}