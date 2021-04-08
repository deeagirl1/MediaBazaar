<?php
//handles data from DB
require_once 'user.class.php';

class UserController extends User {

  public function createUser($username){
    $this->setUser($username);
  }

}
