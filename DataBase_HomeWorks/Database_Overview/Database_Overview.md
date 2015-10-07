# Database systems overview homework

## 1. What database models do you know?
  - Relational (table) model
  - Object model
  - Document model
  - Hierarchical model
  - Hierarchical key-value model
  - Entity–relationship model
  - Network model
  - Associative (Key-value) model
## 2. Which are the main functions performed by a RDBMS?
  Database management systems are designed to manage relational databases. This is the so-called classical Database model that has been an industry standard for many years.
  - Popular RDBMS Servers:
    - Microsoft SQL Server
    - Oracle MySQL
    - PostgreSQL
    - SQLite
  - Using for management of relational data stored in tables.
  - Definition of relational schema (database schema).
  - Creating, modifying, deleting tables and relationships between them.
  - Adding, modifying, deleting, searching and retrieving data stored in tables.
  - SQL Language Support.
  - Management (maintenance) of transactions.
## 3. Define what is table in database terms.
  In database terms a table is an organized and structured way of storing and showing consistent data. Each table consists of rows and columns each row has the same structure as the others and each column has a predefined name, data type(number, string, object, etc.) and possibly other attributes. Having columns with predefined names and data types helps us to guarantee the consistency of the data stored in a given table.
## 4. Explain the difference between a primary and a foreign key.
  In a given database table the Primary key or the index refers to a value which is unique for every row in the table. Having a column/s(we can have a composite Primary key - consisting of several columns in this case the combination of the latter must be unique) of database table with a unique value per row gives us the ability to uniquely identify each row in the table. We can say that the Primary key creates a "key-value pair" where the Primary key is the "key" and all the other data in the row is the "value".
  The Foreign key in a given table is basically the Primary key of another table. We can use the Foreign keys to create relations between different tables. The main difference between a Primary and a Foreign key is that while the former must be a unique value for each row the latter doesn't have that constrain - the uniqueness of the foreign key depends on the constrain that we want to use in your relations.
## 5. Explain the different kinds of relationships between tables in relational databases.
  We have three types of relationships between database tables:
  1. One-to-Many:
    - In this type of relationship a single entry from the first table may correspond with more than one entry in the second table.
  2. Many-to-Many:
    - Each record of the first table may have many corresponding entries in the second table and vice-versa.
  3. One-to-One:
    - The most restrictive kind of relationship between tables. Each entry of the first table may correspond only to a single entry from the second table.
## 6. When is a certain database schema normalized?
  A database schema is said to be Normalized after it has passed a process of Normalization. One of the most important results of the process of Normalization is the lack of unnecessary data(repeating value, values that can be calculated on the basis of the rest data, etc.). We have 4 basic type of Normalizations each one of them more restrictive and build on top of the previous. When a certain Normalization is applied we say that the database is in normalized form.
  - What are the advantages of normalized databases?
    - Better structure and understanding of the connections between the data in a given database.
    - Lack of unnecessary data.
## 7. What are database integrity constraints and when are they used?
  Constrains ensure data consistency and integrity.
  Constrains enforce rules over the data in the tables.
  We can use those for:
    - Enforce unique values for Primary keys.
    - Ensures that a given Foreign key value is actually a valid Primary key for another table.
    - Used to constrain data types and values.
## 8. Point out the pros and cons of using indexes in a database.
  1. Pros:
    - Faster data lookup (we have a unique value for each row in the table).
  2. Cons:
    - More disk space "heavy". Databases that use indexing store more additional data.
    - Some administration processes are slower - deletion, adding.
## 9. What's the main purpose of the SQL language?
  To give us a standardized way for communicating with a Database - to perform addition, deletion, edition etc. actions on the data in the database. SQL is an open industry standard language that supports many operations that can be performed on given set of data. On the other hand many companies (Microsoft, Oracle etc.) have their own "flavor" of the SQL language each one having its pros and cons.
## 10. What are transactions used for?
  - Transactions are used for executing many operations in a certain order as a single "batch" operation.
  - Give us the possibility for a "undo/redo" in case of transaction failure. No matter the amount of operations in a given transaction they all have to pass in order to have a successful transaction.
  - Transaction are used to ensure data integrity when working with the database.
  A classic example for a transaction is money withdraw from an ATM machine. The ATM machine must verify your PIN code, check your account status, check if the ATM has enough money... etc. operations to finally give you your salary.
## 11. What is a NoSQL database?
  A NoSQL database is a database which doesn't relay on the relational algebra in contrast to the traditional SQL based databases. Such databases are:
    - Document-based.
    - Document doesn't have fixed structure.
    - Data is stored as documents.
## 12. Explain the classical non-relational data models.
  - A model that doesn't relay on the classical table-key based model enforced my the relational RDBMS.
  - Model that uses document-based data storage and manipulation.
  - Has pros over the classical model when working when accessing large amount of data.
## 13. Give few examples of NoSQL databases and their pros and cons.
  1. Databases:
     - Cassandra (Distributed wide-column database)
     - MongoDB (Mature and powerful JSON-Document database)
     - Redis (Ultra-fast in-memory data structures server)
  2. Models:
     - Document model
     - Associative (Key-value) model
     - Hierarchical key-value model
     - Wide-column model
     - Object model
  3. Pros:
     - Support CRUD operations
     - Support Indexing and querying
     - Support concurrency and transactions
     - Highly optimized for append / retrieve
     - Great performance and scalability
  4. Cons:
     - Difficult administration and support
