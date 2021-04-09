<?php
    if(!session_id())
    {
        session_start();
    }
     if(!isset($_SESSION['ID']))
    {
        header('Location: login.php');
        exit;
    } 
?>