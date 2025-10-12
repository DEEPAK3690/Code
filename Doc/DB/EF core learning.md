# **EF core** 

Entity Framework data access technology.

* **Cross-Platform:** EF Core works on various platforms, including Windows, macOS, and Linux.
* **Code-First Approach:** **In this approach, the data model (classes) is created first, and Entity Framework Core generates the database schema based on the model.
* **Database-First Approach:** **This approach is used when an existing database is available. Entity Framework Core can generate the data model (classes) based on the database schema.

ORM stands for Object-Relational Mapping, a programming technique that allows developers to convert data between incompatible systems, specifically between Object-Oriented Programming Languages (such as C#, Java, etc.) and Relational Databases (such as SQL Server, MySQL, Oracle, etc.).

ORM allows developers to work with data in terms of objects rather than tables and columns. That means ORM automatically creates classes based on database tables,

* **Simplifies Data Access:** ORMs abstract the complexities of data access, allowing developers to interact with the database in an object-oriented rather than writing complex SQL queries.
* **Increased Productivity:** Developers can build applications faster by focusing on the application logic rather than data access details	

## **EF Core Code First Approach:**

In the EF Core Code First Approach, first, we need to create our application domain classes, such as Student, Branch, Address, etc., and a special class (called DBContext Class) that derives from the Entity Framework Core DbContext class.

![1760245790801](image/EFcorelearning/1760245790801.png)

## **Package Installation**

The **EF Core DB Provider Package** is necessary because it allows EF Core to interact with the database. EF Core supports multiple databases, and you need to install the corresponding database provider for the database you want to use (e.g., SQL Server, SQLite, PostgreSQL, etc.).

Without the EF Core Database Provider package, **EF Core cannot perform database operations,** as it doesn’t know how to connect and communicate with the backend database.

SQL server - "**Install-Package Microsoft.EntityFrameworkCore.SqlServer**" - database provider

EF core tool package - "**Install-Package Microsoft.EntityFrameworkCore.Tools**"

![1760246836799](image/EFcorelearning/1760246836799.png)

## **DbContext Class**

The DbContext class is responsible for interacting with the database using the configured database provider

`DbContext` in EF Core acts as a bridge between the application and the database. It tracks entity states, manages queries, and handles data persistence and relationships efficiently.s

```csharp
// Import the Entity Framework Core namespace to access DbContext and other EF Core functionalities.
using Microsoft.EntityFrameworkCore; 

namespace EFCoreCodeFirstDemo.Entities
{
    // EFCoreDbContext class inherits from DbContext, which is the primary class for interacting with the database using EF Core.
    public class EFCoreDbContext : DbContext 
    {
        // Constructor that accepts DbContextOptions<EFCoreDbContext> as a parameter.
        // The options parameter contains the settings required by EF Core to configure the DbContext,
        // such as the connection string and provider.
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
        : base(options) // The base(options) call passes the options to the base DbContext class constructor.
        {
        }

        // OnConfiguring is an override method that allows configuring the DbContext options,
        // like setting the database provider and connection string.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string.
            // UseSqlServer method configures the DbContext to use SQL Server as the database provider.
            // The provided connection string specifies the server, database name, and credentials.
            // Replace "Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;"
            // with your actual SQL Server details.
            optionsBuilder.UseSqlServer("Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;");
        }

        // DbSet<Student> Students represents a table in the database corresponding to the Student entity.
        // EF Core uses DbSet<TEntity> to track changes and execute queries related to the Student entity.
        public DbSet<Student> Students { get; set; }

        // DbSet<Branch> Branches represents a table in the database corresponding to the Branch entity.
        // Similar to the Students DbSet, this property is used by EF Core to track and manage Branch entities.
        public DbSet<Branch> Branches { get; set; }
    }
}
```

![1760248159333](image/EFcorelearning/1760248159333.png)

* **DbContext:** The main class in EF Core for **interacting with the database**. It manages entity objects during runtime and handles database connections.
* **Constructor:** The constructor initializes the DbContext using the options provided, which typically include the database provider and connection string.
* **OnConfiguring Method:** This method configures the DbContext, such as setting the database provider and connection string. It is useful if you don’t provide configuration externally.
* **DbSet `<TEntity>`:** These properties represent collections of entities that EF Core tracks. They correspond to tables in the database, and each entity type (like Student and Branch) maps to a DbSet.

Entity framework core will create two database tables for the above two model classes with the required relationships.

In  **C# and Entity Framework** , an **entity** is simply a  **class that represents data in your application and maps to a table in a database** .

Think of it like this:

* Each **entity class** = a **table** in the database.
* Each **instance of the class** = a **row** in that table.
* Each **property** = a **column** in that table.

##### **Methods Provided by DbContext**

* **Add/Attach/Update/Remove** : Methods for adding, attaching, updating, or removing entities from the context.
* **SaveChanges / SaveChangesAsync:** Persists changes to the database.
* **Find / FindAsync:** Finds an entity by its primary key.
* **Entry:** Provides access to change tracking information for a specific entity.
* **OnConfiguring:** Allows configuring the context options (e.g., connection string) when not using dependency injection.
* **AddRange/ AddRangeAsync:** This function adds a collection of new entities to DbContext with the Added state and starts tracking them. The new entities will be inserted into the database when SaveChanges() or SaveChangesAsync() is called.

##### **Database Connection String**

A database connection string is a string that specifies information about how to connect to a particular database

A typical connection string includes:

* **Server Name:** The name or network address of the database server.
* **Database Name:** The name of the specific database to which to connect.
* **Credentials:** Username and password for authenticating to the database.
* **Other Settings:** Optional parameters like timeout settings, encryption settings, and more.

![1760251778415](image/EFcorelearning/1760251778415.png)

**Connection String Components:**

* **Server=LAPTOP-6P5NK25R\SQLSERVER2022DEV:** Specifies the database server’s name or network address.
* **Database=EFCoreDB1:** Indicates the name of the database to connect to or create if it doesn’t exist yet.
* **Trusted_Connection=True:** Enables Windows Authentication mode, which uses your Windows credentials to connect to the database.
* **TrustServerCertificate=True:** Instructs the connection to trust the server’s SSL certificate without requiring validation of the certificate’s chain of trust. This is often used in development environments.

##### **Entity Framework Core Migration**

Migrations in EF Core are a mechanism to keep your database schema in sync with your EF Core model. As your application evolves, your data model may change, requiring corresponding changes to the database schema. Migrations help manage these changes over time without losing data or creating inconsistencies.

**Migration - "Add-Migration CreateEFCoreDB1"**
