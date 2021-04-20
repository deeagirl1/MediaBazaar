<?php
    if(!session_id())
    {
        session_start();
    }
     if(!isset($_SESSION['loggedin']))
    {
        header('Location: login.php');
        exit;
    } 
?>