# # Logmug

**Logmug** is a small middleware based on **.NET5** which helps developers to logs all incoming requets to their applications into a datastorage.

- Righ now the only provider which is supported is **SqlServer**.
- next provider is mongodb


# How to use it

1- Install the package via nuget in visualstudio :

    Install-Package logmug
 2- Then chose proper provider, like below you can install SqlServer provider

     Install-Package logmug.SqlServer

3- Finally, register **logmug** middleware and pass your connectionstring

    app.UseLogmug(new SqlServerStoreProvider("your connectionstring"));

