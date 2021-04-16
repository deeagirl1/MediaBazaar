<?php

require_once 'dbh.class.php';
require_once 'annoucements.class.php';

class AnnoucementsController extends dbh
{
   /* public function AddAnnoucements(Annoucement $annoucement)
    {
        $sql = "INSERT INTO annoucements(TITLE,DESCRIPTION,EXPIRYDATE) VALUES(:title,:description,:expirydate";
        $sth = $this->connect()->prepare($sql);
        $sth -> execute([
            ':title' => $annoucement->GetTitle(),
            ':description' => $annoucement->GetDescription(),
            ':expiryDate' => $annoucement->GetExpiryDate(),
        ]);
     }*/

     public function GetAnnoucements()
     {
         $annoucements = array();
         $sql = "SELECT * FROM annoucements";
         $sth = $this->connect()->prepare($sql);
         $sth->execute();
    
         if ($sth->rowCount() > 0) {
           // output data of each row
           while($row = $sth->fetch(PDO::FETCH_ASSOC)) {
            //array_push($annoucements, new Annoucements($row["Title"],$row["Description"],$row['PostDate']));
            array_push($annoucements, new Annoucements("Title","Description",'PostDate')); 
          }
           return $annoucements;
         } else {
           return 0;
         }
       
     }
}