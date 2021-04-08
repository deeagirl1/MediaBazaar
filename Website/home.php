<?php
// We need to use sessions, so you should always start sessions using the below code.
include 'includes/class-autoload.inc.php';
session_start();

// If the user is not logged in redirect to the login page...
if (!isset($_SESSION['loggedin'])) {
	header('Location: index.php');
	exit;
}

$username = $_SESSION['name'];
$password = $_SESSION['password'];
$id = $_SESSION['id'];
?>

<!DOCTYPE html>
<html>

<head>
	<meta charset="utf-8">
	<title>Home Page</title>
	<link href="style.css" rel="stylesheet" type="text/css">
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.1/css/all.css">
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>

<body class="loggedin">
	<nav class="navtop">
		<div>
			<h1><a href="home.php">Media Bazaar</a></h1>
			<a href="profile.php"><i class="fas fa-user-circle"></i>Profile</a>
			<a href="messages.php"><i class="far fa-times-circle"></i></i>Notify Absence</a>
			<a href="logout.php"><i class="fas fa-sign-out-alt"></i>Logout</a>
		</div>
	</nav>
	<div class="content">
		<h2>Welcome back, <?= $_SESSION['name'] ?>!</h2>
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
			$result[(date('w', strtotime($day['date'])) + 6) % 7][$day['shift']] = true;
		}

		$checked = '<i class="fas fa-check-circle"></i>';

		?>

		<div>
			<a href="/home.php?date=
				<?php
				$prevDate = date_create($date);
				date_add($prevDate, date_interval_create_from_date_string(-7 . " days"));
				echo date_format($prevDate, "Y-m-d");
				?>">previous week</a>

			<span>
				<?php echo date_format($startDate, "Y-m-d"); ?> - <?php echo date_format($endDate, "Y-m-d"); ?>
			</span>

			<a href="/home.php?date=
				<?php
				$nextDate = date_create($date);
				date_add($nextDate, date_interval_create_from_date_string(7 . " days"));
				echo date_format($nextDate, "Y-m-d");
				?>">next week</a>
		</div>

		<table class="table table-bordered">
			<thead>
				<tr>
					<th scope="col"></th>
					<th scope="col">Morning</th>
					<th scope="col">Afternoon</th>
					<th scope="col">Evening</th>
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
								if($result[$i][$j]){
									echo $checked;
								}
								?>
							</td>
						<?php } ?>
					</tr>
				<?php } ?>

				<div style="display: none;">
					
				</div>
			</tbody>
		</table>
	</div>
</body>

</html>
