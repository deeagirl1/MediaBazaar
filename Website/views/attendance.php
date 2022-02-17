<?php
require('phpScripts/isSessionValid.php');

?>
<section>
<link rel="stylesheet" href="css/attendance.css">
<div class="container">

 
    <h1>Attendance</h1>
    <hr>
    <p>Next shift is going to be on: </p>
    <br>
    <?php
    require('phpScripts/displayCurrentShift.php');
    ?>
    <br>
    <form action="phpScripts/checkIn.php" method ="POST">

    <button type="submit" class="btn">Check in</button>

    </form>

    <form action="phpScripts/checkOut.php">

    <button type="submit" class="btn">Check out</button>

    </form>   
     
        
    <br>
    <br>
    
    <hr>
    

</div>
</section>