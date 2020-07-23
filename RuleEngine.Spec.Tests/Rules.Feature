 Feature: Order processing system
  In order to Process orders for a large company
  As a user
  I want an order processing Engine
  So that i can process different type of payments done for an order
  
  Scenario: Order Payment for physical product
   Given Order Payment 
    When the order contians a 'PhysicalProduct'
    And I Run the RuleEngine
    Then Generate packaging slip for shipping
    And Generate a Commission payment to agent

    Scenario: Order Payment for book
   Given Order Payment
    When  the order contians a 'Book'
    And I Run the RuleEngine
    Then Create Duplicate packaging slip for royalty department
    And Generate a Commission payment to agent

Scenario: Order Payment for MemberShip
   Given Order Payment
    When  the order contians a 'MemberShip'
    And I Run the RuleEngine
    Then Activate MemberShip
    And inform the owner for activation

Scenario: Order Payment for MemberShip Upgrade
   Given Order Payment
    When  the order contians a 'MemberShipUpgrade'
    And I Run the RuleEngine
    Then Upgrade MemberShip 
    And inform the owner for Upgrade


Scenario: Order Payment for Video Learning to ski
   Given Order Payment
    When  the order contians a 'Video' 
    And Video name is 'Learning to Ski'
    And I Run the RuleEngine
    Then package slip contains free First Aid video
    
    

