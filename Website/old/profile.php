<?php
// We need to use sessions, so you should always start sessions using the below code.
include 'includes/class-autoload.inc.php';
session_start();
// If the user is not logged in redirect to the login page...
if (!isset($_SESSION['loggedin'])) {
	header('Location: index.php');
	exit;
}

?>

<!DOCTYPE html>
<html>

<head>
	<meta charset="utf-8">
	<title>Profile Page</title>
	<link href="style.css" rel="stylesheet" type="text/css">
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css">
</head>

<body class="loggedin">
	<nav class="navtop">
		<div>
			<h1><a href="home.php">Media Bazaar</a></h1>
			<a href="home.php"> Back </a>
			<a href="profile.php"><i class="fas fa-user-circle"></i>Profile</a>
			<a href="logout.php"><i class="fas fa-sign-out-alt"></i>Logout</a>
		</div>
	</nav>
	<div class="content">
		<h2>Profile Page</h2>
		<div>
		<p>Your account details are below:</p>
			<?php
			$test = new UserView();
			$show = $test->showUserDetails($_SESSION['id']);
			$name = $show->GetFirstName();
			$days = $show->GetDaysOff();
			$day = $days[1];
			echo "$day";
			echo "$name";
			
			?>

			<ul class="list-group">
				<li class="list-group-item"> <b>Username: </b> </li>
				<li class="list-group-item">E-mail: </li>
				<li class="list-group-item">First Name: </li>
				<li class="list-group-item">Last Name: </li>
				<li class="list-group-item">Gender: </li>
				<li class="list-group-item">Birthplace: </li>
				<li class="list-group-item">Nationality: </li>
				<li class="list-group-item">City: </li>
				<li class="list-group-item">Role: </li>
				<li class="list-group-item">BSN: </li>
				<li class="list-group-item">Department: </li>
				<li class="list-group-item">Salary: </li>
				<li class="list-group-item">Contract start date: </li>
				<li class="list-group-item">Contract end date: </li>
			</ul>
			<a href="/edit-profile.php">edit</a>
		</div>
	</div>
</body>

</html>