<?php
//gets data from DB
require_once 'dbh.class.php';

class User extends Dbh
{

  protected function getUserDetails($username, $password)
  {
    $sql = "SELECT * FROM person WHERE Username = ? AND Password = ?";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([$username, $password]);
    $results = $stmt->fetchAll();
    return $results;
  }

  public function login($username, $password)
  {
    $sql = "SELECT * FROM person WHERE Username = :username AND Password = :password";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([':username'=>$username,':password'=> $password]);
    $results = $stmt->fetchAll();
    return $results;
  }

  public function getShifts($id, $startDate, $endDate)
  {
    $sql = "SELECT user_id, date, shift
            FROM user_schedules
            WHERE user_id = ?
            AND date >= ?
            AND date <= ?
            ORDER BY date ASC
  ";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([$id, date_format($startDate, "Y-m-d"), date_format($endDate, "Y-m-d")]);
    $results = $stmt->fetchAll();
    return $results;
  }

  public function getManagers()
  {
    $sql = "SELECT id, Username
            FROM users
            WHERE Role = 1
  ";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute();
    $results = $stmt->fetchAll();
    return $results;
  }

  public function editProfil($email, $city, $id)
  {
    $sql = "UPDATE users 
    SET 
        Email = ?,
        Town = ?
    WHERE
        id = ?;";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([$email, $city, $id]);
  }



  // protected function setUser($username) {
  //
  //   $sql = "INSERT INTO users(username) VALUES (?)";
  //   $stmt = $this->connect()->prepare($sql);
  //   $stmt->execute([$username]);
  // }


}
