<?php

class Post extends Dbh {

  public function getShifts() {
    $sql = "SELECT * FROM shifts";
    $stmt = $this->connect()->query($sql);
    while($row = $stmt->fetch()) {
      echo $row['postDesc'] . '///';
      echo $row['postTag'] . '<br>';
    }
  }

}
