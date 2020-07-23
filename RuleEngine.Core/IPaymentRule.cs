using System;
using RuleEngine.Entity;

namespace RuleEngine.Core
{
    public interface IPaymentRule
    {
     bool IsApplicable(Item item);

    RuleLog Apply(Item item);
    }
}
