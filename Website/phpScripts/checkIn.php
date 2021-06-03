<?php
require('isSessionValid.php');
//require_once('../classes/contactcontroller.class.php');
require_once("../classes/usercontroller.class.php");
?>

<?php
    //$messages = new ContactController();
    $userController = new UserController();

    $result = $userController->getShiftsForCheck($_SESSION['ID']);

    foreach($shift as $result){
        echo $shift;
    }
 
    if(isset($_POST['Topic']) &&
   isset($_POST['Message'])
  )
  {
      $topic = $_POST['Topic'];
      $message = $_POST['Message'];
      $sender = $userController->GetUserDetails($_SESSION['ID']);
      
      
      $messages->SendMessage(new Contact($sender->GetID(),$topic,$message));
      echo "<script>alert('Succesfull!'); document.location='../index.php?page=contact';</script>";
    }
    else 
    {
        echo "<script>alert('Something went wrong, please try again.</script>";
    }

?>