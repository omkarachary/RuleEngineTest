using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class MemberShipUpgradeRule : IPaymentRule
    {
        public RuleLog Apply(Item item)
        {
            return new RuleLog{RuleName="Membership Upgrade Rule" ,Activity="Membership Upgrade Activated & Informed Owner of Upgradation"};

        }

        public bool IsApplicable(Item item)
        {
           return item.ItemType==ItemType.MemberShipUpgrade;
        }
    }
}