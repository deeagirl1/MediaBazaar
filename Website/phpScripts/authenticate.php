<?php
include '../includes/class-autoload.inc.php';
session_start();

//check if the data from the login form was submitted, isset() will check if the data exists.
if ( !isset($_POST['username'], $_POST['password']) ) {
	// Could not get the data that should have been sent.
	exit('Please fill both the username and password fields!');
}

$testlog = new UserController();
if($testlog->login($_POST['username'], $_POST['password'])){
	$results = $testlog->login($_POST['username'], $_POST['password']);
	foreach ($results as $result) {

	// store password for session and id for displaying shifts
	$password = $result['Password'];
	$id = $result['ID'];
	$email = $result['Email'];
	}
}

	if ($_POST['password'] === $password) {
		// Verification success! User has loggedin!
		// Create sessions so we know the user is logged in
		session_regenerate_id();
		$_SESSION['loggedin'] = TRUE;
		$_SESSION['name'] = $_POST['username'];
		$_SESSION['password'] = $password;
		$_SESSION['id'] = $id;
		$_SESSION['email'] = $email;
		header('Location: ../index.php');
	}
?>
