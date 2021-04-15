<?php
//handles data from DB
require_once 'dbh.class.php';
require_once 'contact.class.php';

class ContactController extends dbh
{
    public function SendMessage(Contact $contact)
    {
        $sql = "INSERT INTO contactmessages(SENDER,TOPIC,TEXT) VALUES (:sender,:topic,:text)";
        $sth = $this->connect()->prepare($sql);
        $sth->execute([
            ':sender' => $contact->GetSender(),
            ':topic' => $contact-> GetTopic(),
            ':text' => $contact->GetText()
        ]);
    }

   /* public function GetMessages()
    {
      $messages = array();
      $sql = "SELECT * FROM contactmessages";
      $sth = $this->conn->prepare($sql);
      $sth->execute();
 
      if ($sth->rowCount() > 0) {
        // output data of each row
        while($row = $sth->fetch(PDO::FETCH_ASSOC)) {
         array_push($this->foods, new Contact($row[$_SESSION['ID']],$row["Sender"],$row["Topic"],$row["Text"],$row["DateTime"]));
        }
        return $this->foods;
      } else {
        return 0;
      }
    }*/

}
?>