# RequestManager
The Request Manager project is a ASP.NET MVC based Application. I use .Net Framework 4.7.2 , Entity Framework, jQuery, Datatable, Chartjs to Create this project. And the test database is in the database.zip file please unzip it and put under the App_Data folder for testing.

The login page linked to database's "Users" table which store the user's info (including name, password, department and all the default password is Admin123@), users can use their full name and password to login then create requests and view all requests. And in the login page I use cookies, and modified the default controller template to response the user’s language choices. The whole web application load important text from Resource files, I use this method to achieve the bilingual requirement.

The index page is designed for posting data to create newrequests in the database's Request datable. Which stores the project name,department name, user name, description, and create time. The form using ajax topartially update the user name dropdown list based on the chosen departmentname's dropdown list. And use both HTML 'required' tag and Request model to makesure all the fields are taped in. And the RequestPost action response to the form post.

And in the Viewall page, I use datatable to display all the requests, and use the datatable's plugin could make users easily search for keywords in any column.

And in the Chart page, I use Chartjs to show the tickets' number of each project.

Future Improvement: use md5 and salt to encrypt the password, create more functions such as, users could manage the status of the request(pending, solved, in progress).

