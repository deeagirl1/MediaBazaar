<?php
require('isSessionValid.php');
require_once('../classes/usercontroller.class.php');
?>
<?php
$users = new UserController();


if(isset($_POST['psw']) &&
   isset($_POST['new-psw']) &&
   isset($_POST['psw-repeat']) 
  )
    {
        $currentPassword = $_POST['psw'];
        $newPassword = $_POST['new-psw'];
        $repeatNewPassword = $_POST['psw-repeat'];
        $email = $_SESSION['EMAIL']; 
        $id = $_SESSION['ID'];

        if($newPassword === $repeatNewPassword)
        {
                if($users->ChangePassword($email,$id, $currentPassword, $newPassword) == true){
                    echo "<script>alert('Succesfull!');document.location='../index.php?page=myaccount'; </script>"; 
                }
                else echo "<script>alert('Invalid password supplied');document.location='../index.php?page=myaccount'; </script>"; 
                return;
        }
        else{
            echo "<script>alert('Passwords must be same');document.location='../index.php?page=myaccount';  </script>"; 
        } 
}    
?>