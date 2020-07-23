using System.Collections.Generic;
using RuleEngine.Core;
using RuleEngine.Entity;
using Xunit;

namespace RuleEngine.Tests
{
    public class PhysicalProductRuleShould
    {
        [Fact]
        public void SatifyIfItemTypeInOrderIsAPhysicalProduct()
        {
            var item=new Item{Id=1,ItemType=ItemType.PhysicalProduct,Name="someProduct"};

            var productRule=new PhysicalProductRule();

            var actual=productRule.IsApplicable(item);

            Assert.True(actual);
        }

             [Fact]
        public void ApplysForPhysicalProduct()
        {
            var item=new Item{Id=1,ItemType=ItemType.PhysicalProduct,Name="someProduct"};

            var productRule=new PhysicalProductRule();

            var actual=productRule.Apply(item);

            Assert.NotNull(actual);
            Assert.IsType(typeof(RuleLog), actual);
        }

                 [Fact]
        public void ApplicationReturnsARuleLog()
        {
            var item=new Item{Id=1,ItemType=ItemType.PhysicalProduct,Name="someProduct"};

            var productRule=new PhysicalProductRule();

            var actual=productRule.Apply(item);

            Assert.IsType(typeof(RuleLog), actual);
        }

        
                 [Fact]
        public void GeneratesAPackageSlipForItem()
        {
            var item=new Item{Id=1,ItemType=ItemType.PhysicalProduct,Name="someProduct"};

            var productRule=new PhysicalProductRule();

            var actual=productRule.Apply(item);

            Assert.Equal("Package Slip Generated",actual.Activity);
        }
    }
}