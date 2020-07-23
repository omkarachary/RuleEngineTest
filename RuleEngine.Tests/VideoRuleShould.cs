using RuleEngine.Core;
using RuleEngine.Entity;
using Xunit;

namespace RuleEngine.Tests
{
    public class VideoRuleShuld
    {
       [Fact]
        public void SatifiesForLearningToSkiVideo()
        {
            var item=new Item{Id=1,ItemType=ItemType.Video,Name="Learning to Ski"};

            var videoRule=new VideoRule();

            var actual=videoRule.IsApplicable(item);

            Assert.True(actual);
        }

             [Fact]
        public void ApplyForLearningToSkiVideo()
        {
            var item=new Item{Id=1,ItemType=ItemType.Video,Name="Learning to ski"};

            var rule=new VideoRule();

            var actual =rule.Apply(item);

            Assert.NotNull(actual);
            Assert.IsType(typeof(RuleLog), actual);
        }

                 [Fact]
        public void ApplicationReturnsARuleLog()
        {
            var item=new Item{Id=1,ItemType=ItemType.Video,Name="Learning to ski"};

            var rule=new VideoRule();

            var actual=rule.Apply(item);

            Assert.IsType(typeof(RuleLog), actual);
             Assert.Equal("Video Rule", actual.RuleName);
        }

        
                 [Fact]
        public void AddsFreeVideoToPackage()
        {
            var item=new Item{Id=1,ItemType=ItemType.Video,Name="Learning to ski"};

            var rule=new VideoRule();

            var actual=rule.Apply(item);

            Assert.Contains("First Aid Video Added to packing slip for Free",actual.Activity);
        }

                   [Fact]
        public void NotApplicalForOtherVideos()
        {
            var item=new Item{Id=1,ItemType=ItemType.Video,Name="someProduct"};

            var rule=new VideoRule();

            var actual=rule.IsApplicable(item);

            Assert.False(actual);
            
        }
    }
}