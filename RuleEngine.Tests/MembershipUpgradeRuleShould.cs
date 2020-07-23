using RuleEngine.Core;
using RuleEngine.Entity;
using Xunit;

namespace RuleEngine.Tests
{
    public class MembershipUpgradeRuleShould
    {
               [Fact]
        public void SatifyIfItemTypeInOrderIsAMembershipUpgrade()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShipUpgrade,Name="Some Product"};

            var rule=new MemberShipUpgradeRule();

            var actual=rule.IsApplicable(item);

            Assert.True(actual);
        }

             [Fact]
        public void ApplysForMembership()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipUpgradeRule();

            var actual=rule.Apply(item);

            Assert.NotNull(actual);
            Assert.IsType(typeof(RuleLog), actual);
        }

                 [Fact]
        public void ApplicationReturnsARuleLog()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipUpgradeRule();

            var actual=rule.Apply(item);

            Assert.IsType(typeof(RuleLog), actual);
            Assert.Equal("Membership Upgrade Rule", actual.RuleName);

        }

        
                 [Fact]
        public void ActivateMembershipUpgrade()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipUpgradeRule();

            var actual=rule.Apply(item);

            Assert.Contains("Membership Upgrade Activated",actual.Activity);
        }

                   [Fact]
        public void InformOwnerViaEmailOfUpgrade()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="Membership"};

            var rule=new MemberShipUpgradeRule();

            var actual=rule.Apply(item);

            Assert.Contains("Informed Owner of Upgradatio",actual.Activity);
        }
        
    }
}