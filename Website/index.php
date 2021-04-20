<?php
require('phpScripts/isSessionValid.php');
?>
<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="utf-8">
    <title>Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/homepage.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
  </head>
  <body>
    <nav>
      <input type="checkbox" id="check">
      <label for="check" class="checkbtn">
        <i class="fas fa-bars"></i>
      </label>
      <label class="logo"><a href= "index.php" style = "text-decoration: none; color: white">Media Bazaar</a></label>
      <ul>
        <li><a class="active" href="index.php?page=announcements">Announcements</a></li>
        <li><a href="index.php?page=myaccount">My Account</a></li>
        <li><a href="index.php?page=calendar">Your Schedule</a></li>
        <li><a href="index.php?page=contact">Contact</a></li>
        <li><a><?php require('phpScripts/showName.php')?></a></li>
        <li><a href="index.php?page=logout">Logout</a></li>
    </ul>
  
    </nav>
    <?php 
            $requestedPage = 'views/annoucements.php';
            if(isset($_GET['page']))
            {
                switch ($_GET['page']) {
                    case 'myaccount':
                        $requestedPage = 'views/myaccount.php';
                        break;
                    case 'calendar':
                        $requestedPage = 'views/calendar.php';
                        break;   
                    case 'contact':
                          $requestedPage = 'views/contact.php';
                          break;    
                    case 'logout':
                        $requestedPage = 'phpScripts/logout.php';
                        break;         
                }
            } 
            require $requestedPage;   
?>        
  </body>
</html>
