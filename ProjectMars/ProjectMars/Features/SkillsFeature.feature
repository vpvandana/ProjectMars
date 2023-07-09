Feature: SkillsFeature

As a Mars user, 
I should be able to add, Update and Delete Skills that I have, 
so that buyers can know the Skill set I have


Scenario Outline: TC_003_01 Add new skills
	Given Launch Mars with valid credentials
	When I add skills '<Skill>'  and '<Level>' I have
	Then New skills '<Skill>' and '<Level>' are added to the list

	Examples: 
	| Skill  | Level    |
	| Coding  | Beginner |
	| Testing | Beginner |


Scenario Outline: TC_003_02 Update the existing skill and level
Given Launch Mars and login with valid credentials
When I Update the existing skill and skill level '<skill>' and '<slevel>'
Then The record is updated'<skill>' and '<slevel>'

Examples: 
| skill   | slevel |
| Testing | Intermediate |


Scenario: TC_003_08 Delete skill by clicking cancel icon
Given Launch Mars and login with valid credentials
When I click on cancel icon of added skill
Then Skill deleted successfully from list

