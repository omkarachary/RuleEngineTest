using TechTalk.SpecFlow;
using System;
using Xunit;
using RuleEngine.Entity;
using RuleEngine.Core;
using System.Collections.Generic;

namespace RuleEngine.Spec.Tests.steps
{

  [Binding]
  public class RuleSteps
  {
    private Payment payment;
    private IList<RuleLog> ruleLogs;
    private readonly RuleEvaluator ruleEvaluator;

    public RuleSteps()
    {
        var rules=new List<IPaymentRule>() {new PhysicalProductRule(),new BookRule(),new MemberShipRule(),new MemberShipUpgradeRule(),new VideoRule()};
        this.ruleEvaluator=new RuleEvaluator(rules);
    }
      [Given(@"Order Payment")]
      public void GivenOrderPayment(){
          this.payment=new Payment();
      }

      [When(@"the order contians a '(.*)'")]
      public void WhenOrderContains(string itemType){
        this.payment.Items=new List<Item>{new Item{ItemType=(ItemType)Enum.Parse(typeof(ItemType),itemType)}};
      }

[When(@"I Run the RuleEngine")]
      public void RunRuleEngine(){
        this.ruleLogs= this.ruleEvaluator.Run(this.payment);

      }


     [Then(@"Generate packaging slip for shipping")]
      public void GeneratePackagingslips(){
        Assert.Equal("Physical Product Rule",this.ruleLogs[0].RuleName);
         Assert.Contains("Package Slip generated for Shipping",this.ruleLogs[0].Activity);
      }

   [Then(@"Generate a Commission payment to agent")]
      public void GenerateCommission(){
        Assert.Contains("Commission payment generated for Agent",this.ruleLogs[0].Activity);
      }

   [Then(@"Create Duplicate packaging slip for royalty department")]
      public void GenerateDuplicateSlip(){
        Assert.Contains("Duplicate Slip generated for Royalty Dept",this.ruleLogs[0].Activity);
      }

 [Then(@"Upgrade MemberShip")]
         public void ThenUpgradeMemberShip()
         {
             Assert.Contains("Membership Upgrade Activated",this.ruleLogs[0].Activity);
         }

          [Then(@"inform the owner for activation")]
         public void ThenInformTheOwnerForActivation()
         {
            Assert.Contains("Informed Owner of Activation",this.ruleLogs[0].Activity);
         }

            [Then(@"inform the owner for Upgrade")]
         public void ThenInformTheOwnerForUpgrade()
         {
            Assert.Contains("Informed Owner of Upgradation",this.ruleLogs[0].Activity);
         }

        [When(@"Video name is '(.*)'")]
        public void WhenVideoNameIs(string videoName)
        {
            
            Assert.Contains("Learning to Ski",videoName);
            this.payment.Items[0].Name=videoName;
        }
        
        [Then(@"package slip contains free First Aid video")]
        public void ThenPackageSlipContainsFreeVideo()
        {
           Assert.Contains("First Aid Video Added to packing slip for Free",this.ruleLogs[0].Activity);
        }
 [Then(@"Activate MemberShip")]
         public void ThenActivateMemberShip()
         {
            Assert.Contains("Membership Activated",this.ruleLogs[0].Activity);
         }
            
  }

}