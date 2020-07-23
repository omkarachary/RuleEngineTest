using RuleEngine.Core;
using RuleEngine.Entity;
using Xunit;

namespace RuleEngine.Tests
{
    public class BookRuleShuld
    {
       [Fact]
        public void SatifyIfItemTypeBook()
        {
            var item=new Item{Id=1,ItemType=ItemType.Book,Name="Some Book"};

            var bookRule=new BookRule();

            var actual=bookRule.IsApplicable(item);

            Assert.True(actual);
        }

             [Fact]
        public void ApplysForBook()
        {
            var item=new Item{Id=1,ItemType=ItemType.Book,Name="someProduct"};

            var rule=new BookRule();

            var actual =rule.Apply(item);

            Assert.NotNull(actual);
            Assert.IsType(typeof(RuleLog), actual);
        }

                 [Fact]
        public void ApplicationReturnsARuleLog()
        {
            var item=new Item{Id=1,ItemType=ItemType.Book,Name="someProduct"};

            var rule=new BookRule();

            var actual=rule.Apply(item);

            Assert.IsType(typeof(RuleLog), actual);
             Assert.Equal("Book Rule", actual.RuleName);
        }

        
                 [Fact]
        public void GeneratesAPackageSlipForShipping()
        {
            var item=new Item{Id=1,ItemType=ItemType.Book,Name="someProduct"};

            var rule=new BookRule();

            var actual=rule.Apply(item);

            Assert.Contains("Duplicate Slip generated for Royalty Dept",actual.Activity);
        }

                   [Fact]
        public void GeneratesACommissionForAgent()
        {
            var item=new Item{Id=1,ItemType=ItemType.Book,Name="someProduct"};

            var rule=new BookRule();

            var actual=rule.Apply(item);

            Assert.Contains("Commission payment generated for Agent",actual.Activity);
        }
    }
}