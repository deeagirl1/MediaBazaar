<?php

require_once 'dbh.class.php';
  class Message extends Dbh
  {
    public function insertMessage($name, $email, $messageText, $messageReason, $receiverId)
    {
      try{
        $query="INSERT INTO messages2 (name, email, message, messageReason, receiverId) VALUES (?, ?, ?, ?, ?)";
        $stmt = $this->connect()->prepare($query);
        $stmt->execute([$name, $email, $messageText, $messageReason, $receiverId]);

      } catch (PDOException $e) {
        echo "DataBase Error: The message could not be added.<br>".$e->getMessage();
      } catch (Exception $e) {
        echo "General Error: The user could not be added.<br>".$e->getMessage();
      }
    }
  }
 ?>
