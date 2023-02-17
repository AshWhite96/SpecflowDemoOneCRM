Feature: ActivityLog
	Testing on chrome, edge & firefox

@OneCRM
Scenario Outline: Login to OneCRM navigate Activity log page, delete first 3 items and verify they have been deleted
	Given I navigate to OneCRM and navigate to activity log page
		| Browser	| BrowserVersion	| OS   |
		| <Browser> | <BrowserVersion>  | <OS> |
	When I search delete first '3' logs
	Then I can verify logs have been deleted

	Examples: 
	| Browser | BrowserVersion | OS    |
	| chrome  | 109.0.5414.121 | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| edge    | 110.0.1587.46  | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| firefox | 110.0		   | Win11 |