(function() {

  var sammyApp = Sammy('#content', function() {

    this.get('#/', homeController.all);

	this.get('#/users', usersController.all);
    this.get('#/users/register', usersController.register);
	
    this.get('#/data', data1Controller.all);
    this.get('#/data/add', data1Controller.add);
  });

  $(function() {
    sammyApp.run('#/user');

	/*
	* Here we manipulate the visibility in the index.html page
	* based on whether we have a logged in user or not. 
	*/
    if (data.users.hasUser()) {
      $('#container-sign-in').addClass('hidden');
      $('#btn-sign-out').on('click', function() {
        data.users.signOut()
          .then(function() {
            document.location = '#/';
            document.location.reload(true);
          });
      });
    } else {
      $('#container-sign-out').addClass('hidden');
      $('#btn-sign-in').on('click', function(e) {
      	e.preventDefault();
        var user = {
          username: $('#tb-username').val(),
          password: $('#tb-password').val()
        };
        data.users.signIn(user)
          .then(function(user) {
            document.location = '#/';
            document.location.reload(true);
          }, function(err) {
            $('#container-sign-in').trigger("reset");
            toastr.error(err.responseText);
          });
      });
    }
  });
}());