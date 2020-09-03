# RequestManager
This is a ASP.NET MVC based Application. I use .Net Framework 4.7.2 , jQuery, Datatable, Chartjs to Create this project. And the test database is in the database.zip file please unzip it and put under the App_Data folder for testing.

The login page linked to database's "Users" table which store the user's info (including name, password, department and all the default password is Admin123@), users can use their fullname and password to login then create requests and view all requests.

The index page is designed for posting data to create new requests in the database's Request datable. Which store the project name, department name, user name, description, and create time. The form use ajax to partially reflash the user name dropdownlist based on the chosen of department name's dropdownlist. And use both HTML 'required' tag and Request model to make sure all the fields are taped in. And the RequestPost action response the post.

And in the Viewall page, I use datatable to display all the requests, and use the datatable's plugin could make users easily search the keyword for any column in the table.

And in the Chart page, I use Chartjs to show the tickets' number of each project.
