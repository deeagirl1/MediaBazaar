<?php
require_once('User.php');
require_once('dbh.php');
?>

<?php
class UserCollection extends Dbh
{
   public $users = [];

   public function Set($array)
   {
      $this->users = $array;
   }

   public function Add(User $user)
   {
        $sql = "INSERT INTO user(EMAIL,PASS,FIRSTNAME,LASTNAME,STREET,STREETNR,ZIPCODE,CITY) VALUES (:email,:pass,:firstname,:lastname,:street, :streetnr, :zipcode, :city)";
        $sth = $this->conn->prepare($sql);
        $sth->execute([
         ':email' => $user->GetEmail(),
         ':firstname' => $user->GetFirstName(),
         ':lastname' => $user->GetLastName(),
         ':street' => $user->GetStreet(),
         ':streetnr' => $user->GetStreetNr(),
         ':zipcode' => $user->GetZipcode(),
         ':city' => $user->GetCity(),
         ':pass' => $user->GetPassword()
        
     ]);
        
   }

   public function ChangePassword(string $email,string $currentPassword, string $newPass)
   {
      $sql = "UPDATE user SET Pass=:newPass WHERE Email = :email ";
      $sth = $this->conn->prepare($sql);

      if($this->isValid($email,$currentPassword) != null)
      {
      $sth->execute([
         ':email' => $email,
         ':newPass' => $newPass
      ]);
      }
   }

   public function isValid($email, $password) 
   {
    if(isset($email) && isset($password))
    {
      $sql = 'SELECT ID, FIRSTNAME, LASTNAME, STREET, STREETNR, ZIPCODE, CITY FROM user WHERE EMAIL = :email AND PASS = :pass';
      $sth = $this->conn->prepare($sql);
      $sth->execute([
          ':email' => $email,
          ':pass' => $password
         
      ]);

      if( $sth->rowCount() == 1 )
      {
         $result = $sth->fetch();
         return new User($result['ID'],$email,$result['FIRSTNAME'],$result['LASTNAME'], $result['STREET'] , $result['STREETNR'] , $result['ZIPCODE'], $result['CITY'], $password);
      }
      else {return null;}
    }
    else
    {
       return null;
    }
   } 
}
?>