<?php
require('isSessionValid.php');
?>

<?php
    if(!isset($_SESSION['MyAccountReadonly'])){
        $_SESSION['MyAccountReadonly'] = true;
    } 
    if($_SESSION['MyAccountReadonly'] == true){
        $_SESSION['MyAccountReadonly'] = false;
    }
    else $_SESSION['MyAccountReadonly'] = true;
    header('location: ../index.php?page=myaccount');
?>