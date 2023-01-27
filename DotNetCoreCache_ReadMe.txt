How To Implement Caching In The .NET Core Web API Application

Ans:
Caching is the technique of storing the data which are frequently used. Those data can be served faster for any future or subsequent requests by eliminating the unnecessary requests to external data sources.

Why do we need cache mechanism?
Sometimes our application frequently calls the same method and fetch the data from the database. The output of these requests is the same at all times. It doesn't get changed or updated in the database. In this case, we can use caching to reduce the database calls and retrieve the data directly from the cache memory.

There are 3 types of cache available,

*In-Memory Cache - The data are cached in the server's memory.
*Persistent in-process Cache - The data are cached in some file or database.
*Distributed Cache - The data are cached in shared cache and multiple processes. Example: Redis cache


In-Memory Cache
In-Memory cache means storing the cache data on the server's memory.

Pros

It is easier and quicker than other caching mechanisms
Reduce load on Web Services/ Database
Increase Performance
Highly Reliable
It is suited for small and middle applications.
Cons

If the cache is not configured properly then, it can consume the server’s resources.
Increased Maintenance.
Scalability Issues. It is suitable for single server. If we have many servers then, can't share the cache to all servers.