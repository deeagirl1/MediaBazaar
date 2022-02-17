<?php
require('isSessionValid.php');
require_once('../classes/usercontroller.class.php');
?>
<?php
$users = new UserController();

if(isset($_POST['day1']) &&
   isset($_POST['day2']) &&
   isset($_POST['nightShifts']) 
  )
    {
        $id = $_SESSION['ID'];

        echo "".$_POST['nightShifts'].""; 

        if($_POST['nightShifts'] == 'true'){
            $nightShifts = true;
        }
        else $nightShifts = false;

        $users->UpdateDayPreference($id, array($_POST['day1'], $_POST['day2']));
        $users->UpdateNightAvailiability($id, $nightShifts);
        echo "<script>alert('Succesfull!');document.location='../index.php?page=myaccount'; </script>"; 
    }    
?>