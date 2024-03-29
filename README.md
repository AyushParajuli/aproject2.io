# aproject2.io
this project was soley done by me and the certificate of this project is posted in the linkedin 
# What I learned:

Enabling the OpenAPI basically gives you the necessary web design and layouts as a web api template, it also gives an machine readable definition of the api.
•	To create a new api of our own we have to make a project in the visual studio code 
o	2nd the controller and the get () method
o	3rd just run the program
•	And there you have it your first web api
•	To create the minimal api you just have to uncheck the controller check list while creating the project.
o	Every line of the controller will then be handled by the program.cs, which is not very good cause it will get ugly in the later LLM projects.
•	HTTP 2, is the specification an alternative to http 1.1 but does not obsolete it.

# REST in a Nutshell:
•	Rest ( Representational State Transfer) is a design concept its not an technology 
•	it is build ontop of the http.
•	Uses URIs to access resources
•	Uses Http verbs for the operation
•	Using existing infrastructure
# REST Constrains
•	It have one uniform interface
•	Client Service
o	Client server are independent to each other
•	Api
  o	Stateless, HTTP are also stateless
•	Cacheable
  o	Data retrieved from the api should be cacheable.
  o Changing an item or removing an item is not cached
•	Layered System
•	Code on demand
  o	When you return data sometimes you could also return code which are then executed by the client.

# API Design

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/9d2b0dcb-3f13-4401-8410-4cf144c69976)

Here these are the process of getting into the products and its details.

# REST HTTP verbs:
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/ba7798ed-e61b-4261-b997-167825d815e9)


To add and update an existing a product we use the verbs in the rest

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/b22bf929-bcad-4026-836f-449ba187c569)
These are the some of the tools which are used to test the web apis.

# Retrieving Data
-	The apis also have several ControllerBase which handles the user inputs and the http requests and take care all of the rest.
-	[APIController]Class Attribute for some convenience features
-	HTTPGet / Get(),, method and/or attribute to provide the http verb 
  o	http get basically marks a responsible for the get request.

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/66dbab97-5c6a-402b-8675-1ddc96ab0e39)
Here we are using http get attribute and using the [httpget] to make it explicit

Routing With Attributes:
Which urt match with the end point url or which method match with which controller are usually controlled by the routing

[Route(“/products”)] - >  this sends message to the browser saying use /product (like local host 1,2,3,4,5) to call this very specific methods -> URL to call the API

[Route(“/products/{id}”)] -> this marks the id as the placeholder name for what follows in that part of the url, then id is the parameter for that action method. -> Conmtroller action parameter is taken from url.

[Route(“/producs/{id?}”)] ->in this case id is optional this mark the nullable id as the placeholder name, if the data type in the action method is not int then it becomes the nullable int. -> Optional Controller action parameter is taken from the url.
[Route(“/[controller]”)] -> Use controller name in URL, this is the class name – Controller

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/ffb18893-f2d8-4ff6-bcc5-306ecdb538ff)

This is the root for the whole class
For the product class it will be Route(“api/[controller]”) -> this will be the root of our product class
-	for the rest api resource has always the same URI (Uniform Resource Identifier -> it’s a string that identifies a resource)
-	http method tell the system what to do like adding and editing.

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/c9460c33-9704-4920-96c2-a0a8f8cecacd)

Very interestingly there is a loop in the above code, cause product has a category, and category has a product, since we are gonna serialize the product later it will be a infinite loop over category and product, to stop this we have to tell that category property should not be serialized

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/1335f8fc-2e49-45fb-b989-0715b57dcb06)

this will solve the looping problem

# Date Model 
-	Adding Entity Framework core to the project, it will provide an api to work with because of this we donot have to write any sql code
-	Create Model Classes
  -	Create content class for the model classes.
-	Seed the database with some sample data
Installing Microsoft.EntityFramworkCore.InMemory allows us to create database that resides in memory.
When we stop the application the memory database is purged

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/da239abb-1b6c-457b-8c10-02e73e0a6cba)

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/24f4c3a9-75ae-415f-afaf-f01018baddfa)

# Returning Multiple Items
[HttpGet]
Public IEnumerable <Product> GetAllProducts()
{
	Return db.Products.ToList(); 
} 

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/125b25ad-a960-43dd-9715-cb07dd91d01f)


The second method is to use the return type action result
Public ActionResult<IEnumerable <Product>> GetAllProducts()
{
	Var products = db.Products.ToList(); ]
	Return Ok(products);
}
// here the list of product is an argument to method called Ok, also ok here happens to be a textual description of http status code 200, if everything work as expected
}
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/555ceb00-384c-412e-8f2f-d5b366ba0282)

it happen when I return ok() using the action result
[HttpGet, Route(“/products/{id}”)]
Public ActionResult<IEnumerable <Product>> GetAllProducts()
{
	Var products = db.Products.Find (id); 
	Return products;
}

# Handling Error

What to do when we search for product which is not in the database?
-> 	We should denote an error state with HTTP  status code, the http status code for not finding something is ERROR 404\
  ![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/838f5a01-55c7-4f88-8e11-9f3936828e21)

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/7aa95b6d-73e5-4d90-bee9-2ea02251cd22)

That link in the json will lead us to the part of 404 error describing why it happens
There are helper method for specific error code

# Asynchronous Action

Here we use await while calling the async, which then convert our api to asynchronous one.
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/a497d67c-6760-4ad6-ab44-f716b94ce405)

# WRITING DATA
This section is pretty important cause here we will be writing data to our database previously once we  done with out inmemory data when we refresh out data were gone but now we will have to preserve it

Get -> Get doesnot change the state of the application,
Post -> it allows us to add new data to the application,
Put -> put is used to update the existing data.
Delete ->  it is used to delete the data from the application.

# Model Handling
- Our argument in the action data comes from many sources than the route 
- [From Body] the data here comes from body of http request , it state that the http body should be used and bound to the argument of the method
- [FromRoute] data from the route template
- [FromQuery] data from the URL

# Adding Items
- We add the product with the add() obv giving product to the arg of add
- And save changes () to store in the data base
- We have to return the newly added item with the id,
- To return that newly added we use the CreatedAction
  -	Which comes with the 3 arguments (name of the method, an new object where we set id to the id of product, product)
  -	![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/f4655a5e-375f-4c34-834f-e511e75d4f91)
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/32fe4122-8e10-4df1-9099-96fd5251383d)

Here we have to make the category nullable while adding the the cagatory id and categoryid set to the required, because the virtual category will help retrieve the data but not set up so we need to make it nullable

# Model Validation
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/377d29a2-99c4-4f7f-a1bf-317e599be677)

Here this is the picture from the postman an api tester here it gave error testing why ? because I have set the [Required] to the description as well

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/33acd358-3274-4d1a-b47b-3953ac1f5189)

Well now its created because I added the confriguration in the program.cs

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/777aa54a-c202-414b-b6e2-79c9cf28fe32)

Which validates it even if required is there in the description

# Updating Items
Here put is used to update the item it is actually cool once you try it in post man, 
![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/8f37f642-290c-4e11-adf1-1e72904fa39b)

We verify for the id, then we add modifier then we use try and catch to catch the errors in the code and the dbupdateconcurrancyexception is and error which usually pops.
# Delete Items
Delete item works as it sounds it takes the id of the item and then it erases that item,

![image](https://github.com/AyushParajuli/aproject2.io/assets/94102234/765df914-9eca-4835-bc56-543cb9786ef6)





















