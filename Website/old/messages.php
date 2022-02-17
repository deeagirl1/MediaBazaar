<?php
include 'includes/class-autoload.inc.php';
session_start();

if (!isset($_SESSION['loggedin'])) {
	header('Location: index.php');
	exit;
}

if($_SERVER['REQUEST_METHOD'] === 'POST'){

	if (isset($_POST['message']) && trim($_POST['message']) != '') {

		$messageClass = new Message();
		$messageClass->insertMessage($_SESSION['name'], $_SESSION['email'], $_POST['message'], $_POST['reason'], $_POST['managers']);

//echo 'stanaha neshtata mai';
header('Location: home.php');
}else{
	echo 'Message field is required!';
}
}


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
			<a href="messages.php"><i class="fas fa-user-circle"></i>Notify Absence</a>
			<a href="logout.php"><i class="fas fa-sign-out-alt"></i>Logout</a>
		</div>
	</nav>
	<div class="content">
		<form action='messages.php' method='POST' >
			<section>
				<label>Reason : <input type='text' name='reason'></label>
			</section>
			<section>
				<label>Additional Message: <textarea type='text' name='message'></textarea></label>
			</section>
			<section>
				<label for="managers">Choose Manager:

				<select name='managers'>
				<?php $test = new User();


					foreach ($results = $test->getManagers() as $result) {
						unset($username);
						$receiverId = $result['id'];
						$username = $result['Username'];
						echo '<option value="'.$receiverId.'"  >'.$username.'</option>';
					}
				?>
				</select></label>
			</section>
			<section>
				<input type='submit' name='submit' value='Send'>
			</section>
		</form>
	</div>
</body>
</html>
