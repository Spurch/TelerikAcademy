/*
* This code implies the existence of constant variable
* LOCAL_STORAGE_AUTHKEY_KEY
*/

/*
* Simple code for getting data from a given url
* on the server.
*/
  function getData() {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
      }
    };
	 /*
	* Here we need to change 'api/todos' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.get('api/todos', options)
      .then(function(responce) {
        return responce.result;
      });
  }
  
/*
* Simple code for adding data to the server.
*/
  function addData(newData) {
    var options = {
      data: newData,
      headers: {
        'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
      }
    };
	 /*
	* Here we need to change 'api/todos' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.post('api/todos', options)
      .then(function(responce) {
        return responce.result;
      });
  }

/*
* Simple code for updating already existing data
* on the server based on a given dataId.
*/
  function updateData(dataId, newData) {
    var options = {
      data: newData,
      headers: {
        'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
      }
    };
	/*
	* Here we need to change 'api/todos' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.put('api/todos/' + dataId, options)
      .then(function(responce) {
        return responce.result;
      });
  }
