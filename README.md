# RESTApiAccess  
RESTful Api interactor  

Generic RESTful api access methods.  

To initialize:  
```
IRESTRepository _rest = new RESTRepository();
```

Methods:  
GetApi() - get api call  
GetApiStream() - get api call and process more data from response  
PostApi() - post api call with and without datatype sent (use query string for data)  
PutApi() - put api call with and without datatype sent (use query string for data)  
DeleteApi() - delete api call  

All methods allow for adding a Dictionary<string, string> of request headers, default is null  
