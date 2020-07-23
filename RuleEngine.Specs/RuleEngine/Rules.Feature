 Feature: Order processing system
  In order to Process orders for a large company
  As a user
  I want an order processing Engine
  So that i can process different type of payments don for an order
  
  Scenario: Order Payment for physical product
   Given Order 
    When if the order contians a product
    Then Generate packaging slip for shipping
    And Generate a Commission payment to agent

Scenario: Order Payment for book
   Given Order 
    When if the order contians a book
    Then Create Duplicate packaging slip for royalty department
    And Generate a Commission payment to agent

Scenario: Order Payment for Membership
   Given Order 
    When if the order contians a Membership
    Then Activate Membership
    And inform the owner for activation

Scenario: Order Payment for Membership Upgrade
   Given Order 
    When if the order contians a Membership
    Then Upgrade Membership 
    And inform the owner for Upgrade


Scenario: Order Payment for Video "Learning to ski"
   Given Order 
    When if the order contians Video "Learning to ski"
    Then package slip contains free "First Aid" video
    And inform the owner for Upgrade
    



   