<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<?php
    $userController = new UserController();
    $user = $userController->GetUserDetails($_SESSION['ID']);

    echo "<h1>Your information</h1><br><hr>
    <form method='POST' action='action.php'>
    <label for='birthDate'><b>Date of birth</b></label>
    <input type='text' placeholder='Date of birth' name='birthDate' id='birthDate' value ='".date('Y-m-d', strtotime($user->GetBirthDate()))."' readonly>
    <label for='hourlyWage'><b>First working day</b></label>
    <input type='text' placeholder='First working day' name='hireDate' id='hireDate' value ='".date('Y-m-d', strtotime($user->GetHireDate()))."' readonly>
    <label for='hourlyWage'><b>Hourly Wage</b></label>
    <input type='text' placeholder='Hourly Wage' name='hourlyWage' id='hourlyWage' value ='".$user->GetWage()."' readonly>
    <label for='contract'><b>Contract</b></label>
    <input type='text' placeholder='Contract' name='contract' id='contract' value ='".$user->GetContract()."' readonly>
    <label for='department'><b>Department</b></label>
    <input type='text' placeholder='Department' name='department' id='department' value ='".$user->GetDepartment()."' readonly>
    </form><hr>";
?>