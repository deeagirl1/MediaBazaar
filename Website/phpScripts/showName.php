<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<?php
    $userController = new UserController();
    $user = $userController->GetUserDetails($_SESSION['ID']);
    echo "".$user->GetFirstName()." ".$user->GetLastName()."";
?>