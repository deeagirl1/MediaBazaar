<?php
include '../includes/class-autoload.inc.php';
require_once('../classes/usercontroller.class.php');


//check if the data from the login form was submitted, isset() will check if the data exists.
if ( !isset($_POST['username'], $_POST['password']) ) {
	// Could not get the data that should have been sent.
	exit('Please fill both the username and password fields!');
}

$controller = new UserController();
    if(isset($_POST['username']) && isset($_POST['password']))
    {
        $username = $_POST['username'];
        $password = $_POST['password'];
        
        $user = $controller->login($username, $password); 
        if($user != null)
        {
            session_start();
            $_SESSION['loggedin'] = TRUE;
            $_SESSION['ID'] = $user->GetID();
            $_SESSION['EMAIL'] = $user->GetEmail();
            header("Location: ../index.php");  
        }
        else
        {
            echo "<script>alert('Invalid credentials supplied'); document.location='../login.php'; </script>";    
        } 
       
    } 
    
    
?>