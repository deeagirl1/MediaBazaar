<?php
require('isSessionValid.php');
//require_once('../classes/contactcontroller.class.php');
require_once("../classes/usercontroller.class.php");
?>

<?php
    //$messages = new ContactController();
    $userController = new UserController();

    $userController->checkInShift($_SESSION['ID']);

    

?>