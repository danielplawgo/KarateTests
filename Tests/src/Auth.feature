Feature: Auth - fetching jwt token

Background:
    * url baseUrl+"/api/Auth/Login"

Scenario: Featch jwt token
    Given request {"Username":"#(userName)","Password":"#(password)"}
	When method POST
	Then status 200
    And match response contains { "message": "Success" }
    * def token = response.token