<!-- <?php
  include 'includes/class-autoload.inc.php';
 ?>
 <!DOCTYPE html>
 <html lang="en">
 <head>
   <meta charset="utf-8">
   <meta name="viewport" content="width=device-width, initial-slcae=1.0">
   <meta http-equiv="X-UA-Compatible" content="ie=edge">
   <title> Document</title>
 </head>
 <body>

   <form method="POST" action="classes/usercontroller.class.php">
     Username: <input type="text" name="username"><br>

     <button type="submit", name="submit">
       Submit
     </button>

   </form>

<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI Datepicker - Display multiple months</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#datepicker" ).datepicker({
      numberOfMonths: 1,
      showButtonPanel: true
    });
  } );
  </script>
</head>
<body>

<p>Date: <input type="text" id="datepicker"></p>




</body>
</html>

 </body>
 </html> -->

 <!DOCTYPE html>
<html>
	<head>

		<meta charset="utf-8">
		<title>Login</title>
		<link href="style.css" rel="stylesheet" type="text/css">
	</head>
	<body>
		<div class="login">
			<h1>Login</h1>
			<form action="authenticate.php" method="post">
				<label for="username">
					<i class="fas fa-user"></i>
				</label>
				<input type="text" name="username" placeholder="Username" id="username" required>
				<label for="password">
					<i class="fas fa-lock"></i>
				</label>
				<input type="password" name="password" placeholder="Password" id="password" required>
				<input type="submit" value="Login">
			</form>
		</div>
	</body>
</html>
