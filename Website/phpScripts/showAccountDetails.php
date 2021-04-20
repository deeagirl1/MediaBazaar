<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<?php
    $userController = new UserController();
    $user = $userController->GetUserDetails($_SESSION['ID']);

    $mode = "";
    /* if(!isset($_SESSION['MyAccountReadonly'])){
      $mode = "readonly";
    }
    else{
      if($_SESSION['MyAccountReadonly'] == true){
        $mode = "readonly";
      }
      else $mode = "";
    } */
    

    echo "<form method='POST' action='phpScripts/changeDetails.php'>
    <label for='firstName'><b>First Name</b></label>
    <input type='text' placeholder='First Name' name='FirstName' id='firstName' value ='".$user->GetFirstName()."' $mode>
    <label for='lastName'><b>Last Name</b></label>
    <input type='text' placeholder='Last Name' name='LastName' id='lastName' value ='".$user->GetLastName()."' $mode>
    <label for='street'><b>Street</b></label>
    <input type='text' placeholder='Street' name='Street' id='street' value ='".$user->GetStreet()."' $mode>
    <label for='email'><b>Street number</b></label>
    <input type='text' placeholder='Street' name='StreetNr' id='street' value ='".$user->GetStreetNr()."' $mode>
    <label for='email'><b>Zip code</b></label>
    <input type='text' placeholder='Street' name='ZipCode' id='street' value ='".$user->GetZipcode()."' $mode>
    <label for='email'><b>City</b></label>
    <input type='text' placeholder='Street' name='City' id='street' value ='".$user->GetCity()."' $mode>
    <label for='email'><b>Country</b></label>
    <input type='text' placeholder='Street' name='Country' id='street' value ='".$user->GetCountry()."' $mode>
    <label for='email'><b>Email</b></label>
    <input type='text' placeholder='Email' name='Email' id='email' value ='".$user->GetEmail()."' $mode>
    <label for='accountNumber'><b>Account Number</b></label>
    <input type='text' placeholder='Account Number' name='Account' id='accountNumber' value ='".$user->GetAccountNr()."' $mode>
    <button type='Change' class='passwordbtn'>Save</button>
    </form><hr>";
?>