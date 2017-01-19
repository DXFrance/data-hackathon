# Azure SQL DataWarehouse

Azure SQL DataWarehouse is a relational database.
Compute is separated from storage. You can store a few TB and have 1 node to compute it, or have 10 nodes to compute 2 GB.
You can even have 0 compute nodes when you don't use it. 

You can create a cluster in a few seconds.

Azure SQL DataWarehouse comes with polybase which makes it easy to load data from and to Azure Blob Storage. It's just SQL with external tables (like in Hive).

The main documentation is here: <https://azure.microsoft.com/en-us/documentation/services/sql-data-warehouse/>.

In particular, you should see the following: 
- <https://azure.microsoft.com/en-us/documentation/articles/sql-data-warehouse-overview-what-is/>
- <https://azure.microsoft.com/en-us/documentation/articles/sql-data-warehouse-get-started-provision/>
- <https://azure.microsoft.com/en-us/documentation/articles/sql-data-warehouse-connect-overview/>
- <https://azure.microsoft.com/en-us/documentation/articles/sql-data-warehouse-load-from-azure-blob-storage-with-polybase/>
