using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class VideoRule : IPaymentRule
    {
     

        public bool IsApplicable(Item item)
        {
            return item.ItemType==ItemType.Video && item.Name=="Learning to Ski";
        }

           public RuleLog Apply(Item item)
        {
            return new RuleLog{RuleName="Video Rule",Activity="First Aid Video Added to packing slip for Free"};
        }
    }
}