<?php
require('phpScripts/isSessionValid.php');
require_once('classes/usercontroller.class.php');
?>
<section>
<link rel="stylesheet" href="css/callinsick.css">
<div class="container">
<form action="phpScripts/callInSick.php" method = "POST">
 
    <h1>Call in sick</h1>
    <br>
    <hr>
    <div>
        <label for="message"><b>Shift</b></label>
        <br>
        <?php 
        $test = new UserController();
        //var_dump($results = $test ->getDatesAfterToday(42));
        $results = $test ->GetClosestShiftDetails($_SESSION['ID']);
        echo $results;
        $_SESSION['storredShift'] = $results;

        ?>
        <br>
    </div>
    <hr>
    <button type="submit" class="btn">Send</button>
</form>
</div>
</section>