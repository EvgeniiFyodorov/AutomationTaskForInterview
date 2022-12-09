Feature: LottoResults

@Front
Scenario: LottoResultsForSevenDays
	Given Lotto web page is opened
	When Button Results is pressed
	  And Date period is set
	  And View filtered resuls button is pressed
	Then There are no results shown that fall outside of a set date period
