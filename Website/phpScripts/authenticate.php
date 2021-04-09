<?php
require_once('../classes/UserCollection.php');
?>

<?php
$users = new UserCollection();
 if(isset($_POST['username']) && isset($_POST['psw']))
{
    $username = $_POST['username'];
    $password = $_POST['psw'];
    
    $user = $users->isValid($username, $password); 
    if($user != null)
    {
        session_start();
        $_SESSION['ID'] = $user->GetID();
        $_SESSION['USERNAME'] = $user->GetID();
        header("Location: ../index.php");  
    }
    else
    {
        echo "<script>alert('Invalid credentials supplied'); document.location='../login.php'; </script>";    
    }
}  
?>