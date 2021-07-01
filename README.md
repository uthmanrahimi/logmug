
# # Logmug

**Logmug** is a small middleware based on **.NET5** which helps developers to logs all incoming requets to their applications into a datastorage.

**Avaiable Providers**

 - SQLServer
 - SQLite
 - MongoDB (coming soon)

# How to use it

1- Install the package via nuget in visualstudio :

    Install-Package logmug
 2- Then chose proper provider, like below you can install SqlServer provider

     Install-Package logmug.SqlServer

3- Finally, register **logmug** middleware and pass your connectionstring

    app.UseLogmug(new SqlServerStoreProvider("your connectionstring"));

## Customization
If you don't like default table name in each provider, you can use your own name. To do this, you can set your own name while you are regesting **logmug** middleware  like below:

    app.UseLogmug(new SqlServerStoreProvider("your connectionstring").TableName("MyTable"));
