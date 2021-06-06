<?php
//handles data from DB
require_once 'dbh.class.php';
require_once 'user.class.php';

class UserController extends Dbh{

  public function GetUserDetails($id)
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

    if($stmt->rowCount() == 1)
      {
         $result = $stmt->fetch();
         return new User($result['ID'],$result['Email'],$result['Username'], $result['FirstName'],
         $result['LastName'] ,$result['Street'], $result['StreetNumber'],$result['ZipCode'],
         $result['City'],$result['Country'],$result['Password'], $result['BirthDate'],$result['HireDate'],
         $result['LastWorkingDay'],$result['Wage'], $result['AccountNumber'],$result['Department'],
         $result['ContractFixed'] ,$result['ContractHours'], $result['NightShifts'],$this->GetShifhtPrefernces($id));
      }
      else {return null;}
  }

  private function GetShifhtPrefernces($id){
    $sql = "SELECT s.Day FROM shiftpreference s INNER JOIN employee e ON s.Employee = e.ID WHERE e.ID = :id";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([':id' => $id ]);
    $days = [];

    if ($stmt->rowCount() > 0) {
      while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
       array_push($days, $row['Day']);
      }
      return $days;
    } else {
      return array(0,0);
    }  
  }

  public function login($username, $password)
  {
    $sql = "SELECT * FROM person WHERE Username = :username AND Password = :password";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([':username'=>$username,':password'=> $password]);
    if( $stmt->rowCount() == 1 ){
      $result = $stmt->fetch();
      $user = $this->GetUserDetails($result['ID']);
      return $user;  
    }
    else return null;  
    
  }

  public function getShifts($id, $startDate, $endDate)
  {
      $sql = "SELECT 
        ea.EmployeeID AS user_id,
        ws.Date AS date,
        ws.ShiftType AS shift
      FROM employeeassignment AS ea
        INNER JOIN workshift AS ws 
        ON ws.ID = ea.ShiftID 
      WHERE ea.EmployeeID = ?
      AND (ws.Date BETWEEN ? AND ?)
        ORDER BY ws.Date ASC";
    
    $begin = date_format($startDate, "Y-m-d 00:00:00");
    $end = date_format($endDate, "Y-m-d 23:59:59");
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([$id, $begin , $end]);
    $results = $stmt->fetchAll();
    return $results;
  }

  public function UpdateDetails(User $user){
    $sql = "UPDATE person SET Email = :email, FirstName = :fname, LastName = :lname WHERE ID = :id;
            UPDATE employee SET Country = :country, City = :city, Street = :street, StreetNumber = :streetNr,
            ZipCode = :zipCode, AccountNumber = :account  WHERE ID = :id;";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([
      ':email' => $user->GetEmail(),
      ':fname' => $user->GetFirstName(),
      ':lname' => $user->GetLastName(),
      ':country' => $user->GetCountry(),
      ':city' => $user->GetCity(),
      ':street' => $user->GetStreet(),
      ':streetNr' => $user->GetStreetNr(),
      ':zipCode' => $user->GetZipCode(),
      ':account' => $user->GetAccountNr(),
      ':id' => $user->GetID()
    ]);
  }

  public function ChangePassword(string $email,string $id,string $currentPassword, string $newPass)
  {
     $sql = "UPDATE person SET Password=:newPass WHERE ID = :id";
     $stmt = $this->connect()->prepare($sql);

     if($this->login($email,$currentPassword) != null)
     {
        $stmt->execute([
           ':id' => $id,
           ':newPass' => $newPass
       ]);
       return true;    
     }
     return false;
  }

  
  public function UpdateDayPreference(int $UserID, array $days){
    $empty = true;
    foreach($days as $var){
      if($var!=0){
        $empty = false;
      }
    }
    $this->removeShifts($UserID);
    if($empty == false){
      foreach($days as $var){
        $this->insertShift($UserID, $var);
      } 
    }
  }

  public function UpdateNightAvailiability(int $UserID, bool $res){
    $sql = "UPDATE employee SET NightShifts = :res WHERE ID = :id";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([
        ':id' => $UserID,
        ':res' => $res
    ]);
  }


private function insertShift(int $UserID, int $day){
    $sql = "INSERT INTO shiftpreference(Employee, Day) VALUES(:employee, :shiftDay)";
    $stmt = $this->connect()->prepare($sql);

    $stmt->execute([
        ':employee' => $UserID,
        ':shiftDay' => $day
    ]);
}

private function removeShifts(int $UserID){
    $sql = "DELETE FROM shiftpreference WHERE Employee = :id";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([
        ':id' => $UserID
    ]);
}

public function checkInShift($UserID){
  $sql = "UPDATE employeeassignment SET CheckIn = CURRENT_TIMESTAMP WHERE ID =  :id";
  $stmt = $this->connect()->prepare($sql);
  $stmt->execute([
      ':id' => $UserID
  ]);
  return true;
}

public function checkOutShift($UserID){
  $sql = "UPDATE employeeassignment SET CheckOut = CURRENT_TIMESTAMP WHERE ID =  :id";
  $stmt = $this->connect()->prepare($sql);
  $stmt->execute([
      ':id' => $UserID
  ]);
  return true;
}

public function getShiftsCheckInAndOut($UserID) 
{
  $sql = "SELECT employeeassignment.ID FROM employeeassignment inner join workshift on employeeassignment.shiftID = workshift.ID
          WHERE EmployeeID = :id and workshift.Date > CURRENT_TIMESTAMP ORDER by workshift.Date ASC ";
  $stmt = $this->connect()->prepare($sql);
  $stmt->execute([
    ':id' => $UserID
  ]);
  if ($stmt->rowCount() > 0) {
    while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
     return $row['ID'];
     break;
    }
  }
}

  public function GetClosestShiftDetails($UserID)
  {
    $sql = "select * from workshift inner join employeeassignment on workshift.ID = employeeassignment.ShiftID 
            where employeeassignment.ID = :id";
    $stmt = $this->connect()->prepare($sql);
    $stmt->execute([
      ':id' => $this->getShiftsCheckInAndOut($UserID)
    ]);
    if ($stmt->rowCount() > 0) {
      while($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
       return $row['Date'];
       break;
      }
    }
    
  }
}



