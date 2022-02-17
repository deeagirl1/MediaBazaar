<?php
require('isSessionValid.php');
//require_once('../classes/contactcontroller.class.php');
require_once("../classes/usercontroller.class.php");
?>

<?php
    
    $userController = new UserController();
    $test = $userController->getShiftsCheckInAndOut($_SESSION['ID']);
    if( $userController->checkInShift($test) != null)
    {
    
      echo "<script>alert('Successfully checked-in!'); document.location='../index.php?page=attendance'; </script>";  
    }

?>