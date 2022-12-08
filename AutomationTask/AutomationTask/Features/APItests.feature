Feature: APItests

Scenario: CheckStatus
	When Request 'health' to 'http://affiliate-feed.petfre.sgp.bet/1' URL is made
	Then Service key is returned with status OK

Scenario: CountriesCountForLanguages
	When Request 'countries?languageCode=' to 'http://affiliate-feed.petfre.sgp.bet/1' URL is made for each of following parameters:
	| parameter |
	| en        |
	| es        |
	| bg        |
	Then Country count is same for all responses
