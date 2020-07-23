using System.Collections.Generic;
using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public class RuleEvaluator
    {
        private readonly IEnumerable<IPaymentRule> rules;
        public RuleEvaluator(IEnumerable<IPaymentRule> rules)
        {
            this.rules = rules;

        }
        public IList<RuleLog> Run(Payment payment)
        {
            var logs=new List<RuleLog>();
            foreach(var rule in rules)
            {
                foreach(var item in payment.Items)
                if(rule.IsApplicable(item))
                {
                    logs.Add(rule.Apply(item));
                }
            }

            return logs;

      }
    }
}