<?php
require('phpScripts/isSessionValid.php');
?>
<section>
<link rel="stylesheet" href="css/contact.css">
<div class="container">
<form action="phpScripts/AddMessage.php" method = "POST">
 
    <h1>Contact</h1>
    <hr>
    <label for="topic"><b>Topic</b></label>
    <input type="text" placeholder="Topic" name="Topic" id="Topic" required>
    <br>
    <br>
    <label for="message"><b>Message</b></label>
    <textarea type="text" placeholder="Message" name="Message" id ="Message" rows="10" cols="68"></textarea><br>
    <hr>

    <button type="submit" class="btn">Send</button>
</form>
</div>
</section>