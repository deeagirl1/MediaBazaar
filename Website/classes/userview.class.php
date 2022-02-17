<?php
require_once 'usercontroller.class.php';

class UserView extends UserController {
  
  public function showUserDetails($id) {
    $results = $this->getUserDetails($id);
    return $results;
  }

}
