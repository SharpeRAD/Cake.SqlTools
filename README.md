# Cake.SqlTools
Cake Build addin for executing sql scripts against a database

[![Build status](https://ci.appveyor.com/api/projects/status/l726ygqbcja9emgb?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-sqltools)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.SqlTools#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.SqlTools#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.SqlTools#usage)
4. [Example](https://github.com/SharpeRAD/Cake.SqlTools#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.SqlTools#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.SqlTools#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.SqlTools#share-the-love)



## Implemented functionality

* Execute a query against a database
* Contains a provider for MS Sql, MySql and PostgreSQL



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.SqlTools.svg?style=flat)](https://www.nuget.org/packages/Cake.SqlTools/)

Cake.SqlTools is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.SqlTools
```

or directly in your build script via a cake addin directive:

```csharp
#addin "Cake.SqlTools"
```



## Usage

```csharp
#addin "Cake.SqlTools"

Task("Execute-Sql-Query")
    .Description("Execute a Sql query against a database.")
    .Does(() =>
{
    ExecuteSqlQuery("CREATE DATABASE Test", new SqlQuerySettings()
    {
        Provider = "MsSql",
        ConnectionString = "blah"
    });
});

Task("Execute-Sql-File")
    .Description("Execute a Sql query  against a database, from the contents of a file.")
    .Does(() =>
{
    ExecuteSqlFile("./Scripts/Restore-DB.sql", new SqlQuerySettings()
    {
        Provider = "MsSql",
        ConnectionString = "blah"
    });
});

RunTarget("Execute-Sql-Query");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.SqlTools/blob/master/test/build.cake).



## TroubleShooting

* Please be aware of the breaking changes that occurred with the release of [Cake v0.22.0](https://cakebuild.net/blog/2017/09/cake-v0.22.0-released), you will need to upgrade Cake in order to use Cake.SqlTools v0.1.0 or above.



## Plays well with

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.SqlTools is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.SqlTools/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.