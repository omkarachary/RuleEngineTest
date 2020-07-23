using System;
using System.Collections.Generic;
using Xunit;
using RuleEngine.Core;
using RuleEngine.Entity;
using Moq;

namespace RuleEngine.Tests
{
    public class RuleEvaluatorShould
    {
        [Fact]
        public void RunRulesOnAnOrderAndReturnRuleLog()
        {
            var evaluator=new RuleEvaluator(new List<IPaymentRule>());
            var actual=evaluator.Run(new Payment{});

            Assert.IsType(typeof(List<RuleLog>),actual);
        }

             [Fact]
        public void ReturnsEmptyLogIfnoRules()
        {
            var evaluator=new RuleEvaluator(new List<IPaymentRule>());
            var actual=evaluator.Run(new Payment{});

            Assert.Empty(actual);
        }

        [Fact]
        public void ApplyApplicableRules()
        {
            var paymentRule=new Mock<IPaymentRule>();
            paymentRule.Setup(r=>r.IsApplicable(It.IsAny<Item>())).Returns(true);
            paymentRule.Verify(r=>r.Apply(It.IsAny<Item>()),Times.AtMostOnce());
            
            var evaluator=new RuleEvaluator(new List<IPaymentRule>());
            var actual=evaluator.Run(new Payment{});

            paymentRule.Verify(r=>r.Apply(It.IsAny<Item>()),Times.AtMostOnce());
        }
                [Fact]
        public void SkipNotApplicableRules()
        {
            var paymentRule=new Mock<IPaymentRule>();
            paymentRule.Setup(r=>r.IsApplicable(It.IsAny<Item>())).Returns(false);
            paymentRule.Verify(r=>r.Apply(It.IsAny<Item>()),Times.AtMostOnce());
            
            var evaluator=new RuleEvaluator(new List<IPaymentRule>());
            var actual=evaluator.Run(new Payment{});

            paymentRule.Verify(r=>r.Apply(It.IsAny<Item>()),Times.Never());
        }
        
        
    }
}
