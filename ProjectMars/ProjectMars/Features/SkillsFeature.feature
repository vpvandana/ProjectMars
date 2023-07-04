Feature: SkillsFeature

As a Mars user, 
I should be able to add, Update and Delete Skills that I have, 
so that buyers can know the Skill set I have


Scenario Outline: TC_003_01 Add new skills
	Given Launch Mars with valid credentials
	When I navigate to skills section in profile page
	And I add skills '<Skills>' and '<Level>' I have
	Then New skills are added to the list '<Skills>' and '<Level>'
Examples: 
| Skills  | Level    |
| Coding  | Beginner |
| Testing | Beginner |