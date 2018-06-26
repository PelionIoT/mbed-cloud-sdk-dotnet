PaginatedResponse objects used in API list endpoints now takes `MaxResults` and `PageSize` to remove the ambiguity of the `limit` parameter.
Data property in PaginatedResponse has been removed. Please use the iterator instead. 
