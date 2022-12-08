Feature: LottoResults

Scenario: LottoResultsForSevenDays
	Given Web page 'https://www.oddsking.com/lotto/irish' is opened
	When Button Results is pressed
	  And Date period is set
	  And View filtered resuls button is pressed
	Then There are no results shown that fall outside of a set date period
