Feature: SpecFlowTasks

@Task 1.1
Scenario: Testing The Title Of The First Article
	Given I have navigated to BBC site
	When I click the News link
	Then the title of the first article should have the following value:
    | First Article                                  | 
    | Hong Kong protests trample rule of law - China | 		 

@Task 1.2
Scenario: Testing The Titles Of The Secondary Articles
 	Given I have navigated to BBC site
	When I click the News link
	Then the titles of the secondary articles should have the following values:
    | Secondary Articles                                         |    
    | Protests mark opening of European Parliament               |
    | Secret 'border patrol Facebook group' investigated         |
    | Deadly floods bring Mumbai to standstill                   |
    | School shooting teacher's story revealed as hoax           |
    | Who is Gauff, the 15 - year - old who beat Venus Williams? |

@Task 1.3
Scenario: Testing The Presence Of The First Article In The Search Results By Article Category
 	Given I have navigated to BBC site
	When I click the News link
	And I enter the Category of the first article in the Search bar
	And I press the Search button
	Then the title of the first searched article should have the following value:
    | First Searched Article  |    
    | One - minute World News |

@Task 2.2
Scenario: Positive Testing: User Can Fill The Question Form With Valid Information
	Given I have generated the Lorem ipsum string
	When I have navigated to BBC site
	And I click the News link
	And I click the More link (the second one)
	And I click the Have your say link
	And I click the Do you have a question for BBC news? link
	Then I successfully fill the question form with valid information
	And I take a screenshot and save it on my PC

@Task 2.3.1
Scenario: Negative Testing: User Fill The Question Form With Invalid Information (question field consists of 141 characters)
	Given I have generated the Lorem ipsum string
	When I have navigated to BBC site
	And I click the News link
	And I click the More link (the second one)
	And I click the Have your say link
	And I click the Do you have a question for BBC news? link
	Then I fill the question form with invalid information (question field consists of 141 characters)
	And I take a screenshot and save it on my PC

@Task 2.3.2
Scenario: Negative Testing: User Fill The Question Form With Invalid Information (the "Name" input field is empty)
	Given I have generated the Lorem ipsum string
	When I have navigated to BBC site
	And I click the News link
	And I click the More link (the second one)
	And I click the Have your say link
	And I click the Do you have a question for BBC news? link
	And I fill the question form with invalid information: the Name input field is empty 
	And I click the Submit button
	Then Color of Name input label is red
	And Border Color of Name input field is red

@Task 2.3.3
Scenario: Negative Testing: User Fill The Question Form With Invalid Information (the "Email address" input field is empty)
	Given I have generated the Lorem ipsum string
	When I have navigated to BBC site
	And I click the News link
	And I click the More link (the second one)
	And I click the Have your say link
	And I click the Do you have a question for BBC news? link
	And I fill the question form with invalid information: the Email address input field is empty 
	And I click the Submit button
	Then Color of Email address label is red
	And Border Color of Email address input field is red