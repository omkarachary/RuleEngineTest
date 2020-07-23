using RuleEngine.Core;
using RuleEngine.Entity;
using Xunit;

namespace RuleEngine.Tests
{
    public class MembershipRuleShould
    {
               [Fact]
        public void SatifyIfItemTypeInOrderIsAMembership()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="Some Product"};

            var rule=new MemberShipRule();

            var actual=rule.IsApplicable(item);

            Assert.True(actual);
        }

             [Fact]
        public void ApplysForMembership()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipRule();

            var actual=rule.Apply(item);

            Assert.NotNull(actual);
            Assert.IsType(typeof(RuleLog), actual);
        }

                 [Fact]
        public void ApplicationReturnsARuleLog()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipRule();

            var actual=rule.Apply(item);

            Assert.IsType(typeof(RuleLog), actual);
            Assert.Equal("Membership Rule", actual.RuleName);

        }

        
                 [Fact]
        public void ActivateMembership()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="someProduct"};

            var rule=new MemberShipRule();

            var actual=rule.Apply(item);

            Assert.Contains("Membership Activated",actual.Activity);
        }

                   [Fact]
        public void InformOwnerViaEmail()
        {
            var item=new Item{Id=1,ItemType=ItemType.MemberShip,Name="Membership"};

            var rule=new MemberShipRule();

            var actual=rule.Apply(item);

            Assert.Contains("Informed Owner of Activation",actual.Activity);
        }
        
    }
}