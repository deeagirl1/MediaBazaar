<?php
require('isSessionValid.php');
//require_once('../classes/contactcontroller.class.php');
require_once("../classes/usercontroller.class.php");
?>

<?php
    
    $userController = new UserController();
    $test = $userController->getShiftsCheckInAndOut($_SESSION['ID']);
    if( $userController->checkOutShift($test) != null)
    {
      echo "<script>alert('Successfully checked-out!'); document.location='../index.php?page=attendance'; </script>";  
    }
?>