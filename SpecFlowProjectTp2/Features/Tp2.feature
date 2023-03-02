Feature: Tp2

A short summary of the feature

@tag1
Scenario: Vote validation
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 10    |
      |    Yoan    | 10    |
      |    Carla   | 10    |
    And we have 30 voters
    When All voters have voted
    Then the vote closing flag should be true
    
Scenario: Vote winner
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 30    |
      |    Yoan    | 15    |
      |    Carla   | 5     |
    And we have 50 voters
    When All voters have voted
    Then the winner is Charlie with 60.00 percente votes

Scenario: Vote no winner
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 30    |
      |    Yoan    | 25    |
      |    Carla   | 10    |
    And we have 65 voters
    When All voters have voted
    Then there is no winner
    Then the second turn candidate are 
     | candidates | votes | percentage |
     | Charlie    | 30    | 46.15      |
     | Yoan       | 25    | 38.46      |


Scenario: Second turn vote
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 30    |
      |    Yoan    | 25    |
      |    Carla   | 10    |
    And we have 65 voters
    When All voters have voted
    Then the second turn candidate are 
     | candidates | votes | percentage |
     | Charlie    | 30    | 46.15      |
     | Yoan       | 25    | 38.46      |
    Given the vote is open 
    And following candidates and votes
      | candidates | votes |
      |    Charlie | 38    |
      |    Yoan    | 27    |
    And we have 65 voters
    When All voters have voted
    Then the winner is Charlie with 58.46 percente votes

Scenario: get all result
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 30    |
      |    Yoan    | 25    |
      |    Carla   | 10    |
    And we have 65 voters
    When All voters have voted
    Then the result is 
     | candidates | votes | percentage |
     | Charlie    | 30    | 46.15      |
     | Yoan       | 25    | 38.46      |
     | Carla      | 10    | 15.38      |

Scenario: Second turn no winner
    Given following candidates and votes
      | candidates | votes |
      |    Charlie | 30    |
      |    Yoan    | 30    |
    And we have 60 voters
    When All voters have voted
    Then there is no winner