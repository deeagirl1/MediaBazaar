<?php
require('phpScripts/isSessionValid.php');
?>
<section>
<link rel="stylesheet" href="css/myaccount.css">
<div class="container">

<form action="action.php" method="post">

    <h1>Change password</h1>
    <hr>
    <label for="firstName"><b>First Name</b></label>
    <input type="text" placeholder="First Name" name="firstName" id="firstName" required>
    <br></br>
    <label for="lastName"><b>Last Name</b></label>
    <input type="text" placeholder="Last Name" name="lastName" id="lastName" required>
    <label for="street"><b>Street</b></label>
    <input type="text" placeholder="Street" name="street" id="street" required>
    <label for="email"><b>Email</b></label>
    <input type="text" placeholder="Email" name="email" id="email" required>
    <label for="birthDate"><b>Date of birth</b></label>
    <input type="date" placeholder="Date of birth" name="birthDate" id="birthDate" required>
    <label for="username"><b>Username</b></label>
    <input type="text" placeholder="Username" name="username" id="username" required>
    <label for="password"><b>Password</b></label>
    <input type="password" placeholder="Password" name="password" id="password" required>
    <label for="hourlyWage"><b>Hourly Wage</b></label>
    <input type="text" placeholder="Hourly Wage" name="hourlyWage" id="hourlyWage" required>
    <label for="role"><b>Role</b></label>
    <input type="text" placeholder="Role" name="role" id="role" required>
    <label for="contract"><b>Contract</b></label>
    <input type="text" placeholder="Contract" name="contract" id="contract" required>
    <label for="department"><b>Department</b></label>
    <input type="text" placeholder="Department" name="department" id="department" required>
    <label for="accountNumber"><b>Account Number</b></label>
    <input type="text" placeholder="Account Number" name="accountNumber" id="accountNumber" required>
    <label for="daysPreference">Days Off</label>
    <div class ="custom-select">
 
  <select name="daysPreference" id="daysPreference">
    <option value="Monday">Monday</option>
    <option value="Tuesday">Tuesday</option>
    <option value="Wednesday">Wednesday</option>
    <option value="Thursday">Thursday</option>
    <option value="Friday">Friday</option>
    <option value="Saturday">Saturday</option>
    <option value="Sunday">Sunday</option>
  </select>

  <select name="daysPreference" id="daysPreference">
    <option value="0">Monday</option>
    <option value="1">Tuesday</option>
    <option value="2">Wednesday</option>
    <option value="3">Thursday</option>
    <option value="4">Friday</option>
    <option value="5">Saturday</option>
    <option value="6">Sunday</option>
  </select>
</div>
  <br>
  <label for="nightShits">Night Shifts</label>
  <div class = "checkbox" >
 
  <input type="checkbox" id="yes" name="yes" value="Yes">
  <label for="yes">YES</label>
  <input type="checkbox" id="no" name="no" value="no">
  <label for="no">NO</label>
</div>
</form>
    <hr>

    <button type="Change" class="passwordbtn">Change your password</button>
</form>
</div>
</section>