Feature: RunReport
	Testing on chrome, edge & firefox

@OneCRM
Scenario Outline: Login to OneCRM navigate Reports page, run Project Profitability report and verify results returned
	Given I navigate to OneCRM and navigate to reports page
		| Browser	| BrowserVersion	| OS   |
		| <Browser> | <BrowserVersion>  | <OS> |
	When I search for 'Project Profitability' report and click run report
	Then I can verify results have been returned

	Examples: 
	| Browser | BrowserVersion | OS    |
	| chrome  | 109.0.5414.121 | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| edge    | 110.0.1587.46  | Win11 |

	Examples: 
	| Browser | BrowserVersion | OS    |
	| firefox | 110.0		   | Win11 |