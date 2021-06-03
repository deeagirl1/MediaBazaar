<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>
<section>
<link rel="stylesheet" href="css/attendance.css">
<div class="container">
<form action="../phpScripts/checkIn.php" method = "POST">
 
    <h1>Attendance</h1>
    <hr>
        <?php
        $test = new UserController();

        $result = $test->getShiftsForCheck($_SESSION['ID']);
        //echo $result;
        foreach($result as $shift){
            echo $shift['Date'];
            echo "<br>";
        }
        ?>
    <br>
    <br>
    
    <hr>

    <button type="submit" class="btn">Check in</button>
    <button type="submit" class="btn">Check out</button>
</form>
</div>
</section>