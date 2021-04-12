<?php
require('phpScripts/isSessionValid.php');
//include '../includes/class-autoload.inc.php';
include 'classes/userview.class.php';

$id = $_SESSION['ID'];
?>
<link href="style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

<div class="content">
    <h2>Welcome back!</h2>
    <?php
    if (isset($_SERVER['QUERY_STRING'])) {
        $queries = array();
        parse_str($_SERVER['QUERY_STRING'], $queries);
        if (isset($queries['date'])) {
            $date = $queries['date'];
            echo 'displaying for week of ' . $date;
        } else {
            $date = date('Y-m-d');
            echo 'no date provided, displaying for this week';
        }
    } else {
        $date = date('Y-m-d');
        echo 'no date provided, displaying for this week';
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
    $result = array();
    for ($i = 0; $i < 7; $i++) {
        $result[$i] = array(false, false, false);
    }
    foreach ($show as $day) {
        $result[(date('w', strtotime($day['date'])) + 6) % 7][$day['shift']-1] = true;
    }
    $checked = '<i class="fas fa-check-circle"></i>';
    ?>
    <div>
        <a href="index.php?page=calendar&date=
				<?php
                $prevDate = date_create($date);
                date_add($prevDate, date_interval_create_from_date_string(-7 . " days"));
                echo date_format($prevDate, "Y-m-d");
                ?>">previous week</a>
        <span>
            <?php echo date_format($startDate, "Y-m-d"); ?> - <?php echo date_format($endDate, "Y-m-d"); ?>
        </span>
        <a href="index.php?page=calendar&date=
				<?php
                $nextDate = date_create($date);
                date_add($nextDate, date_interval_create_from_date_string(7 . " days"));
                echo date_format($nextDate, "Y-m-d");
                ?>">next week</a>
    </div>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th style="text-align:center;" scope="col"></th>
                <th style="text-align:center;" scope="col">Morning</th>
                <th style="text-align:center;" scope="col">Afternoon</th>
                <th style="text-align:center;" scope="col">Evening</th>
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
</div>