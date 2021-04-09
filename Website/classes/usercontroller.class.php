<?php
//handles data from DB
require_once 'dbh.class.php';
require_once 'user.class.php';

class UserController extends Dbh{

  protected function getUserDetails($id)
  {
    $sql = "SELECT p.ID, p.FirstName, p.LastName, p.Email, 
    p.Username, p.Password, p.AccessLevel, e.BirthDate, e.HireDate, e.LastWorkingDay, 
    e.Country, e.City,e.Street,e.StreetNumber,e.AddressAddition,e.ZipCode, 
    e.Wage, e.AccountNumber, s.ID as StatusID, s.Status as StatusName,
    d.ID as DepartmentID, d.Name as Department, 
    c.ID as ContractID, c.Fixed as ContractFixed,c.Hours as ContractHours, e.NightShifts 
    FROM PERSON p INNER JOIN EMPLOYEE e ON p.ID = e.ID
    INNER JOIN department d ON e.DepartmentID = d.ID
    INNER JOIN employeeStatus s ON e.Status = s.ID
    INNER JOIN contract c on e.ContractID = c.ID WHERE p.ID = :id";

    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([':id' => $id ]);

    if( $stmt->rowCount() == 1 )
      {
         $result = $stmt->fetch();
         return new User($result['ID'],$result['Email'],$result['Username'], $result['FirstName'],
         $result['LastName'] ,$result['Street'], $result['StreetNumber'],$result['ZipCode'],
         $result['City'] ,$result['Password'], $result['BirthDate'],$result['HireDate'],
         $result['LastWorkingDay'] ,$result['Wage'], $result['AccountNumber'],$result['Department'],
         $result['ContractFixed'] ,$result['ContractHours'], $result['NightShifts'],array(6,7));
      }
      else {return null;}
  }

  public function login($username, $password)
  {
    $sql = "SELECT * FROM person WHERE Username = :username AND Password = :password";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([':username'=>$username,':password'=> $password]);
    if( $stmt->rowCount() == 1 ){
      $results = $stmt->fetchAll();
      return $results;
    }
    else return null;  
    
  }

}
