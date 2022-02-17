<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<?php
    $userController = new UserController();
    $user = $userController->GetUserDetails($_SESSION['ID']);

    $daysOff = $user->GetDaysOff();  
    $nightShifts = $user->IsOnNightShifts();

    $radioYes = "";
    $radioNo = "";

    if($nightShifts == true){
        $radioYes = "checked";
    }
    else $radioNo = "checked";

    $week[0] = 'None';
    $week[1] = 'Monday';
    $week[2] = 'Tuesday';
    $week[3] = 'Wednesday';
    $week[4] = 'Thursday';
    $week[5] = 'Friday';
    $week[6] = 'Saturday';
    $week[7] = 'Sunday';


    if($user->IsContractFixed()==true){
        echo "<h1>Change shift preferences</h1><br><hr>
        <form method='POST' action='phpScripts/updateShiftPreferences.php'>
        <label for='daysPreference'><b>Days off preference</b></label>
        <div class ='custom-select'>";
 
        echo "<select name= 'day1' id='day1'>";
        for($i = 0;$i<8;$i++){
            if($daysOff[0] == $i){
                echo "<option value='$i' selected>".$week[$i]."</option>";
            }
            else echo "<option value='$i'>".$week[$i]."</option>";
        }
        echo "</select>";

        echo "<select name= 'day2' id='day2'>";
        for($i = 0;$i<8;$i++){
            if($daysOff[1] == $i){
                echo "<option value='$i' selected>".$week[$i]."</option>";
            }
            else echo "<option value='$i'>".$week[$i]."</option>";
        }
        echo "</select>";

      echo  "</div>
      <br>
      <label for='nightShits'><b>Availability  for night shifts</b></label>
      <div class = 'checkbox'>
   
      <input type='radio' id='nightShifts' name='nightShifts' value='true' $radioYes>
      <label for='yes'>YES</label>
      <input type='radio' id='nightShifts' name='nightShifts' value='false' $radioNo>
      <label for='no'>NO</label>
      </div>
      <button type='Change' class='passwordbtn'>Save</button>
      </form><hr>"; 
    }       
?>