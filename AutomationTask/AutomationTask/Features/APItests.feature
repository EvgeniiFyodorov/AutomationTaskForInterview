Feature: APItests

Scenario: CheckStatus
	When Request 'health' to specified URL is made
	Then Service key is returned with status OK

Scenario: CountriesCountForLanguages
	When Request 'countries?languageCode=' to specified URL is made for each of following parameters:
	| parameter |
	| en        |
	| es        |
	| bg        |
	Then Country count is same for all responses
