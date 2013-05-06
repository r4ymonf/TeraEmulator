Setup
---------------------

newTeraWAPI.7z Includes all web based files and SQL tables needed for the launcher....

Please extract all data to the your tera web directory....

if you however choose a different directory instead of

/var/www/tera/

Please make sure to edit the launcher source in the WebAPI.cs file

and modify

public string webApiUrl = "http://localhost/tera/webapi.php";

to match your installation directory of the web files....