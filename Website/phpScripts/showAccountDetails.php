<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<?php
    $userController = new UserController();
    $user = $userController->GetUserDetails($_SESSION['ID']);

    $mode = "readonly";
    if(!isset($_SESSION['MyAccountReadonly'])){
      $mode = "readonly";
    }
    else{
      if($_SESSION['MyAccountReadonly'] == true){
        $mode = "readonly";
      }
      else $mode = "";
    }

    echo "<form method='POST' action='action.php'>
    <hr>
    <label for='firstName'><b>First Name</b></label>
    <input type='text' placeholder='First Name' name='firstName' id='firstName' value ='".$user->GetFirstName()."' $mode>
    <label for='lastName'><b>Last Name</b></label>
    <input type='text' placeholder='Last Name' name='lastName' id='lastName' value ='".$user->GetLastName()."' $mode>
    <label for='street'><b>Street</b></label>
    <input type='text' placeholder='Street' name='street' id='street' value ='".$user->GetStreet()."' $mode>
    <label for='email'><b>Street number</b></label>
    <input type='text' placeholder='Street' name='street' id='street' value ='".$user->GetStreetNr()."' $mode>
    <label for='email'><b>Zip code</b></label>
    <input type='text' placeholder='Street' name='street' id='street' value ='".$user->GetZipcode()."' $mode>
    <label for='email'><b>City</b></label>
    <input type='text' placeholder='Street' name='street' id='street' value ='".$user->GetCity()."' $mode>
    <label for='email'><b>Country</b></label>
    <input type='text' placeholder='Street' name='street' id='street' value ='".$user->GetCountry()."' $mode>
    <label for='email'><b>Email</b></label>
    <input type='text' placeholder='Email' name='email' id='email' value ='".$user->GetEmail()."' $mode>
    <label for='birthDate'><b>Date of birth</b></label>
    <input type='text' placeholder='Date of birth' name='birthDate' id='birthDate' value ='".date('Y-m-d', strtotime($user->GetBirthDate()))."' $mode>
    <label for='hourlyWage'><b>Hourly Wage</b></label>
    <input type='text' placeholder='Hourly Wage' name='hourlyWage' id='hourlyWage' value ='".$user->GetWage()."' $mode>
    <label for='contract'><b>Contract</b></label>
    <input type='text' placeholder='Contract' name='contract' id='contract' value ='".$user->GetContract()."' $mode>
    <label for='department'><b>Department</b></label>
    <input type='text' placeholder='Department' name='department' id='department' value ='".$user->GetDepartment()."' $mode>
    <label for='accountNumber'><b>Account Number</b></label>
    <input type='text' placeholder='Account Number' name='accountNumber' id='accountNumber' value ='".$user->GetAccountNr()."' $mode>
    <label for='daysPreference'>Days Off</label>
    <div class ='custom-select'>
 
  <select name='daysPreference' id='daysPreference'>
    <option value='Monday'>Monday</option>
    <option value='Tuesday'>Tuesday</option>
    <option value='Wednesday'>Wednesday</option>
    <option value='Thursday'>Thursday</option>
    <option value='Friday'>Friday</option>
    <option value='Saturday'>Saturday</option>
    <option value='Sunday'>Sunday</option>
  </select>

  <select name='daysPreference' id='daysPreference'>
    <option value='0'>Monday</option>
    <option value='1'>Tuesday</option>
    <option value='2'>Wednesday</option>
    <option value='3'>Thursday</option>
    <option value='4'>Friday</option>
    <option value='5'>Saturday</option>
    <option value='6'>Sunday</option>
  </select>
</div>
  <br>
  <label for='nightShits'>Night Shifts</label>
  <div class = 'checkbox' >
 
  <input type='radio' id='yes' name='nghtshift' value='Yes'>
  <label for='yes'>YES</label>
  <input type='radio' id='no' name='nghtshift' value='no'>
  <label for='no'>NO</label>
</div>
<button type='Change' class='passwordbtn'>Save</button>
</form>";
?>