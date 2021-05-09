<?php

  abstract class Dbh {
    private $username = 'root';
    private $password = '';
    private $host = 'localhost';
    private $dbName = 'mediabazaar';
    protected $conn;

    protected function connect() {
      /* $dsn = 'mysql:host=' . $this->host . ';dbname=' . $this->dbName; */
      $pdo = new PDO("mysql:host=$this->host;dbname=$this->dbName", $this->username, $this->password);
      $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);
      return $pdo;
    }

}
