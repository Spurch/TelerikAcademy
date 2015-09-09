var data = (function() {
/*
* You can use this piece of code for a 
* simple user registration to a given server.
* NOTE: You need to have CryptoJS SHA1 algorithm referenced 
* in your project prior to using it.
*/
const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
	  LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

function register(user) {
    var newUser = {
      username: user.username,
	  /*
	  * We implement a basic&simple yet fast way to hash the user password.
	  * NOTE: This method is not secure enough for real production use.
	  */
      passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

	/*
	* Here we need to change 'api/users' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.post('api/users', {
        data: newUser
      })
      .then(function(responseonse) {
        var user = responseonse.result;
		/*
		* NOTE: Here we are using the constant variables as keys 
		* for the key/value pairing in localStorage.
		* NOTE: Here we get the new user authentication key from 
		* the server right after registration. 
		*/
        localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
        localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
		
        return {
          username: responseonse.result.username
        };
      });
  }
  
/*
* You can use this piece of code for a simple user
* login to a given server.
*/
function signIn(user) {
    var authUser = {
      username: user.username,
      passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
      data: authUser
    };
	/*
	* Here we need to change 'api/users/auth' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.put('api/users/auth', options)
      .then(function(response) {
        var user = response.result;
        localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
        localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
        return user;
      });
  }  

/*
* You can use this piece of code for a simple
* user logout to a given server.
*/
function signOut() {
    var promise = new Promise(function(resolve, reject) {
      localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
      localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
      resolve();
    });
    return promise;
 }
 /*
* You can use this piece of code for a simple
* check if a user is logged into the system.
*/
 function hasUser() {
    return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
      !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
  }

/*
* You can use this piece of code to get 
* all the users currently registered on
* the server. 
* NOTE: This is a server specific functionality!!!
*/
 function usersGet() {
	 /*
	* Here we need to change 'api/users' with the appropriate 
	* server url we want to use!
	*/
    return jsonRequester.get('api/users')
      .then(function(response) {
        return response.result;
      });
 }
 
  return {
    users: {
      signIn,
      signOut,
      register,
      hasUser,
      get: usersGet,
    },
  };
}());