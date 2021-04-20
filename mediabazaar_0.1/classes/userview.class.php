<?php
//shows data from DB
require_once 'user.class.php';

class UserView extends User {

  public function showUserDetails($username, $password) {
    $results = $this->getUserDetails($username, $password);
    return $results;
  }
}
