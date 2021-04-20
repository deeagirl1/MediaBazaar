<?php
require('phpScripts/isSessionValid.php');
//include '../includes/class-autoload.inc.php';
include 'classes/userview.class.php';

$id = $_SESSION['ID'];
?>
<section>
<link rel="stylesheet" href="css/calendar.css">
    <div class ="header">
    <h2><b>Your schedule</b></h2>
    <hr>
    <?php
    if (isset($_SERVER['QUERY_STRING'])) {
        $queries = array();
        parse_str($_SERVER['QUERY_STRING'], $queries);
        if (isset($queries['date'])) {
            $date = $queries['date'];
            echo 'Displaying for week of ' . $date;
        } else {
            $date = date('Y-m-d');
            echo 'No date provided, displaying for this week';
        }
    } else {
        $date = date('Y-m-d');
        echo 'No date provided, displaying for this week';
    }
    
 
    //$date = '2020-10-15'; //date('Y-m-d');
    $startDate = null;
    $endDate = null;
    function getTimeFrame($date, &$startDate, &$endDate)
    {
        $startDate = date_create($date);
        $endDate = date_create($date);
        // echo $date;
        // echo '<br/>';
        $dayOfWeek = $startDate->format('N'); //date('w', $startDate);
        // echo $dayOfWeek;
        // echo '<br/>';
        date_add($startDate, date_interval_create_from_date_string(- ($dayOfWeek - 1) . " days"));
        date_add($endDate, date_interval_create_from_date_string((7 - $dayOfWeek) . " days"));
        // echo date_format($startDate,"Y-m-d");
        // echo '<br/>';
        // echo date_format($endDate,"Y-m-d");
        // echo '<br/>';
    }
    getTimeFrame($date, $startDate, $endDate);
    $test = new UserView();
    //echo $_SESSION['id'];
    $show = $test->getShifts($id, $startDate, $endDate);

    foreach($show as $var){
        echo "<br>".$var['date']."<br>";
    }

    $result = array();
    for ($i = 0; $i < 7; $i++) {
        $result[$i] = array(false, false, false);
    }
    foreach ($show as $day) {
        $result[(date('w', strtotime($day['date'])) + 6) % 7][$day['shift']-1] = true;
    }
    $checked = '<i class="fas fa-check-circle"></i>';
    ?>
      </div>
    <div class= "display-date">
        <a href="index.php?page=calendar&date=
				<?php
                $prevDate = date_create($date);
                date_add($prevDate, date_interval_create_from_date_string(-7 . " days"));
                echo date_format($prevDate, "Y-m-d");
                ?>">Previous week</a>
        <span>
            <?php echo date_format($startDate, "Y-m-d"); ?> - <?php echo date_format($endDate, "Y-m-d"); ?>
        </span>
        <a href="index.php?page=calendar&date=
				<?php
                $nextDate = date_create($date);
                date_add($nextDate, date_interval_create_from_date_string(7 . " days"));
                echo date_format($nextDate, "Y-m-d");
                ?>">Next week</a>
    </div>
    <hr>

    <table class="table table-bordered">
        <thead>
            <tr>
                <th style="text-align:center;" scope="col"></th>
                <th style="text-align:center;" scope="col">Morning</th>
                <th style="text-align:center;" scope="col">Afternoon</th>
                <th style="text-align:center;" scope="col">Night</th>
            </tr>
        </thead>
        <tbody>
            <?php
            for ($i = 0; $i < 7; $i++) {
                $_currentDay = ($i + 1) % 7;
            ?>
                <tr>
                    <th scope="row"><?php echo jddayofweek($i, 1); ?></th>
                    <?php for ($j = 0; $j < 3; $j++) {  ?>
                        <td style="text-align:center;">
                            <?php
                            if ($result[$i][$j]) {
                                echo $checked;
                            }
                            ?>
                        </td>
                    <?php } ?>
                </tr>
            <?php } ?>
           
        </tbody>
    </table>
</section>