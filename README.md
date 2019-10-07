# api
The API for the "Wanderer" application.

Working with .Net Core 3.0

endpoints: 
	debugging: 
		ssl: https://localhost:44388
		no-ssl: http://localhost:3916
	development:
		ssl: https://localhost:5001
		no-ssl:http://localhost:5000
		
The calls would look something like this => https://localhost:5001/api/{controllerName}/{routeName}
