<?php
require('isSessionValid.php');
//require_once('../classes/contactcontroller.class.php');
require_once("classes/usercontroller.class.php");
?>

<?php
    
    $test = new UserController();
    
    echo  $test->GetClosestShiftDetails($_SESSION['ID']);
    echo "<br>";


?>