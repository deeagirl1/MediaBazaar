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
    <label for="message"><b>Optional Message</b></label>
    <textarea type="text" placeholder="Message" name="Message" id ="Message" rows="5" cols="28"></textarea><br>
    <hr>
    <div>
        <label for="message"><b>Shift</b></label>
        <br>
        <?php 
        $test = new UserController();
        //var_dump($results = $test ->getDatesAfterToday(42));
        $results = $test ->getDatesAfterToday($_SESSION['ID']);
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