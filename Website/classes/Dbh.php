<?php
class Dbh {
    private $username = 'root';
    private $password = '';
    private $host = 'localhost';
    private $dbName = 'mediabazaar';
    protected $conn;

    public function __construct() {
        $this->conn = new PDO("mysql:host=$this->host;dbname=$this->dbName", $this->username, $this->password);
        $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }
}
?>

