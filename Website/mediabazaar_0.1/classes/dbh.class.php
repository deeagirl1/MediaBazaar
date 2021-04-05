<?php

  abstract class Dbh {
    private $host = "studmysql01.fhict.local";
    private $user = "dbi454066";
    private $pwd = "7j7eK4cg";
    private $dbName = "dbi454066";

    protected function connect() {
      $dsn = 'mysql:host=' . $this->host . ';dbname=' . $this->dbName;
      $pdo = new PDO($dsn, $this->user, $this->pwd);
      $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
      return $pdo;

    }

}
