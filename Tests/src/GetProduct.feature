Feature: Get product

Background:
    * url baseUrl+'/api/products/1'

Scenario: Get product with id equal 1
	When method GET
	Then status 200
	And match response == {"id":1,"name":"Name-1"}