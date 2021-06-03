<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>

<script>
const handleCheckIn =(e)=>{
    e.preventDefault();
const radios = document.querySelector(".shift-option[checked='']");
console.log(radios);
}
</script>

<section>
<link rel="stylesheet" href="css/attendance.css">
<div class="container">
<form  method = "POST">
 
    <h1>Attendance</h1>
    <hr>
    
    <?php
        $test = new UserController();

        $result = $test->getShiftsForCheck($_SESSION['ID']);

        foreach($result as $shift){
            
            echo $shift['Date'];
            echo "&nbsp;";
            echo "<input class='shift-option' type='radio' name='shift' value={$shift['Date']} ></input>";
            echo "<br>";
        }
        ?>
    <br>
    <br>
    
    <hr>
    <button class="btn" onclick={handleCheckIn(e)}>Check in</button>
    <button type="submit" class="btn">Check out</button>
</form>
</div>
</section>