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
    if($results!=null){
        // store password for session and id for displaying shifts
        $password = $results['Password'];
        $id = $results['ID'];
        $email = $results['Email'];
        session_regenerate_id();
		$_SESSION['loggedin'] = TRUE;
		$_SESSION['name'] = $_POST['username'];
		$_SESSION['password'] = $password;
		$_SESSION['id'] = $id;
		$_SESSION['email'] = $email;
		header('Location: ../index.php');
        }
    }
    else echo "<script>alert('Invalid credentials supplied'); document.location='../login.php'; </script>";    	
?>
