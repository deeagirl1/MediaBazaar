<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<link rel="stylesheet" href="css/style.css">
</head>
<body>

<div class="header">
  <h1>Media Bazaar</h1>
  <br>
  <p>The bazaar of tech</p>
</div>

<div class="container">
  <form method="post" action="phpScripts/authenticate.php">
    <label for="username">Username</label>
    <input type="text" id="username" name="username" required>

    <label for="password">Password</label>
    <input type="password" id="password" name="password" required>

    <input type="submit" value="Submit">
  </form>
</div>

</body>
</html>
