# aproject2.io
this project was soley done by me and the certificate of this project is posted in the linkedin 
Notes
Enabling the OpenAPI basically gives you the necessary web design and layouts as a web api template, it also gives an machine readable definition of the api.
•	To create a new api of our own we have to make a project in the visual studio code 
o	2nd the controller and the get () method
o	3rd just run the program
•	And there you have it your first web api
•	To create the minimal api you just have to uncheck the controller check list while creating the project.
o	Every line of the controller will then be handled by the program.cs, which is not very good cause it will get ugly in the later LLM projects.
•	HTTP 2, is the specification an alternative to http 1.1 but does not obsolete it.

REST in a Nutshell:
•	Rest ( Representational State Transfer) is a design concept its not an technology 
•	it is build ontop of the http.
•	Uses URIs to access resources
•	Uses Http verbs for the operation
•	Using existing infrastructure
REST Constrains
•	It have one uniform interface
•	Client Service
o	Client server are independent to each other
•	Api
o	Stateless, HTTP are also stateless
•	Cacheable
o	Data retrieved from the api should be cacheable.
o	Changing an item or removing an item is not cached
•	Layered System
•	Code on demand
o	When you return data sometimes you could also return code which are then executed by the client.

API Design






	
Here these are the process of getting into the products and its details.

REST HTTP verbs:







	
To add and update an existing a product we use the verbs in the rest

 
These are the some of the tools which are used to test the web apis.

Retrieving Data
-	The apis also have several ControllerBase which handles the user inputs and the http requests and take care all of the rest.
-	[APIController]Class Attribute for some convenience features
-	HTTPGet / Get(),, method and/or attribute to provide the http verb 
o	http get basically marks a responsible for the get request.

In MicroSoft Visual Studio 2022
   
Here we are using http get attribute and using the [httpget] to make it explicit

Routing With Attributes:
Which urt match with the end point url or which method match with which controller are usually controlled by the routing
[Route(“/products”)] - >  this sends message to the browser saying use /product (like local host 1,2,3,4,5) to call this very specific methods -> URL to call the API
[Route(“/products/{id}”)] -> this marks the id as the placeholder name for what follows in that part of the url, then id is the parameter for that action method. -> Conmtroller action parameter is taken from url.
[Route(“/producs/{id?}”)] ->in this case id is optional this mark the nullable id as the placeholder name, if the data type in the action method is not int then it becomes the nullable int. -> Optional Controller action parameter is taken from the url.
[Route(“/[controller]”)] -> Use controller name in URL, this is the class name – Controller
 
This is the root for the whole class
For the product class it will be Route(“api/[controller]”) -> this will be the root of our product class
-	for the rest api resource has always the same URI (Uniform Resource Identifier -> it’s a string that identifies a resource)
-	http method tell the system what to do like adding and editing.
 
Very interestingly there is a loop in the above code, cause product has a category, and category has a product, since we are gonna serialize the product later it will be a infinite loop over category and product, to stop this we have to tell that category property should not be serialized
  this will solve the looping problem\

Date Model 
-	Adding Entity Framework core to the project, it will provide an api to work with because of this we donot have to write any sql code
-	Create Model Classes
o	Create content class for the model classes.
-	Seed the database with some sample data
Installing Microsoft.EntityFramworkCore.InMemory allows us to create database that resides in memory.
When we stop the application the memory database is purged
 
Returning Multiple Items
[HttpGet]
Public IEnumerable <Product> GetAllProducts()
{
	Return db.Products.ToList(); 
} 
 
The second method is to use the return type action result
Public ActionResult<IEnumerable <Product>> GetAllProducts()
{
	Var products = db.Products.ToList(); ]
	Return Ok(products);
}
// here the list of product is an argument to method called Ok, also ok here happens to be a textual description of http status code 200, if everything work as expected
}
 it happen when I return ok() using the action result
[HttpGet, Route(“/products/{id}”)]
Public ActionResult<IEnumerable <Product>> GetAllProducts()
{
	Var products = db.Products.Find (id); 
	Return products;
}
Handling Error

What to do when we search for product which is not in the database?
	We should denote an error state with HTTP  status code, the http status code for not finding something is ERROR 404











That link in the json will lead us to the part of 404 error describing why it happens
There are helper method for specific error code
Asynchronous Action

Here we use await while calling the async, which then convert our api to asynchronous one.
 

WRITING DATA
This section is pretty important cause here we will be writing data to our database previously once we  done with out inmemory data when we refresh out data were gone but now we will have to preserve it

Get -> Get doesnot change the state of the application,
Post -> it allows us to add new data to the application,
Put -> put is used to update the existing data.
Delete ->  it is used to delete the data from the application.
Model Handling
	Our argument in the action data comes from many sources than the route 
	[From Body] the data here comes from body of http request , it state that the http body should be used and bound to the argument of the method
	[FromRoute] data from the route template
	[FromQuery] data from the URL\

Adding Items
	We add the product with the add() obv giving product to the arg of add
	And save changes () to store in the data base
	We have to return the newly added item with the id,
	To return that newly added we use the CreatedAction
o	Which comes with the 3 arguments (name of the method, an new object where we set id to the id of product, product)
o	 







	 
	Here we have to make the category nullable while adding the the cagatory id and categoryid set to the required, because the virtual category will help retrieve the data but not set up so we need to make it nullable
Model Validation
 
Here this is the picture from the postman an api tester here it gave error testing why ? because I have set the [Required] to the description as well
 
Well now its created because I added the confriguration in the program.cs
 
Which validates it even if required is there in the description
Updating Items
Here put is used to update the item it is actually cool once you try it in post man, 
 
We verify for the id, then we add modifier then we use try and catch to catch the errors in the code and the dbupdateconcurrancyexception is and error which usually pops.
Delete Items
Delete item works as it sounds it takes the id of the item and then it erases that item,
 here it finds the item first and the delete it and save the changes
 this one is for the deleting several item.

Next Steps:
	Advance Data Retrieval
	Versioning APIs
	Securing APIs
	Api Design
	Asp.net Core Security
