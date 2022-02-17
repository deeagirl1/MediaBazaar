<?php
require('isSessionValid.php');
require_once('../classes/usercontroller.class.php')
?>

<?php
   $controller = new UserController();

   if( isset($_POST['FirstName'])&&
       isset($_POST['LastName'])&&
       isset($_POST['Email'])&&
       isset($_POST['Country'])&&
       isset($_POST['City'])&&
       isset($_POST['Street'])&&
       isset($_POST['StreetNr'])&&
       isset($_POST['ZipCode'])&&
       isset($_POST['Account']))
       {
           $user = new User();
           $user->SetFirstName($_POST['FirstName']);
           $user->SetLastName($_POST['LastName']);
           $user->SetEmail($_POST['Email']);
           $user->SetCountry($_POST['Country']);
           $user->SetCity($_POST['City']);
           $user->SetStreet($_POST['Street']);
           $user->SetStreetNr($_POST['StreetNr']);
           $user->SetZipCode($_POST['ZipCode']);
           $user->SetAccountNr($_POST['Account']);
           $user->SetID($_SESSION['ID']);

           $controller->UpdateDetails($user);
           echo "<script>alert('Succesfull'); document.location='../index.php?page=myaccount'; </script>";    
       }
?>