<?php

require('isSessionValid.php');
require_once('../classes/usercontroller.class.php');

$test = new UserController();

$test->callInSick($_SESSION['ID']);

echo "<script>alert('Succesfull!'); document.location='../index.php?page=callinsick';</script>";