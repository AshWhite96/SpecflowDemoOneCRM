Feature: CreateContact
	Testing on chrome, edge & firefox

@OneCRM
Scenario Outline: Login to OneCRM navigate to contacts and add a new contact, verify that contact has been created
	Given I navigate to OneCRM and navigate to contacts page
		| Browser	| BrowserVersion	| OS   |
		| <Browser> | <BrowserVersion>  | <OS> |
	And I click create new contact button
	When I enter contact information of firstname 'Test' and lastname 'Test' and categories of 'Customer' 'Suppliers' and click save
	Then I can see contact details and verify they are correct: firstname 'Test' and lastname 'Test' and categories of 'Customer' 'Suppliers'

	Examples: 
	| Browser | BrowserVersion | OS    |
	| chrome  | 109.0.5414.121 | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| edge    | 110.0.1587.46  | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| firefox | 110.0		   | Win11 |