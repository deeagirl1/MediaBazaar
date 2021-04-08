<?php
class User
{
    private $id;
    private $email;
    private $username;
    private $firstName;
    private $lastName;
    private $street;
    private $streetNr;
    private $zipcode;
    private $city;
    private $password;

    private $birthDate;
    private $hireDate;
    private $lastWorkingDay;
    private $wage;
    private $accountNumber;
    private $department;
    private $contractFixed;
    private $workHours;
    private $nightShifts;
    private $daysOff = array();


    public function GetId() : int
    {
        return $this->id;
    }
    public function GetEmail() : string
    {
        return $this->email;
    }
    public function SetEmail(string $firstName)
    {
        $this->email = $email;
    }
    public function GetUsername() : string
    {
        return $this->username;
    }
    public function SetUsername(string $username)
    {
        $this->username = $username;
    }
    public function GetFirstName() : string
    {
        return $this->firstName;
    }
    public function SetFirstName(string $firstName)
    {
        $this->firstName = $firstName;
    }
    public function GetLastName() : string
    {
        return $this->lastName;
    }
    public function SetLastName(string $lastName)
    {
        $this->lastName = $lastName;
    }
    public function GetStreet() : string
    {
        return $this->street;
    }
    public function GetStreetNr() : string
    {
        return $this->streetNr;
    }
    public function GetZipcode() : string
    {
        return $this->zipcode;
    }
    public function GetCity() : string
    {
        return $this->city;
    }
    public function SetStreet(string $street)
    {
        $this->street = $street;
    }
    public function SetStreetNr(string $streetNr)
    {
        $this->streetNr = $streetNr;
    }
    public function SetZipcode(string $zipcode)
    {
        $this->zipcode = $zipcode;
    }
    public function SetCity(string $city)
    {
        $this->city = $city;
    }
    public function GetPassword() : string
    {
        return $this->password;
    }
    public function SetPassword(string $password)
    {
        $this->password = $password;
    }
    public function GetBirthDate()
    {
        return $this->birthDate;
    }
    public function GetHireDate()
    {
        return $this->hireDate;
    }
    public function GetLastWorkingDate()
    {
        return $this->lastWorkingDate;
    }
    public function GetWage() : Float
    {
        return $this->lastWorkingDate;
    }
    public function GetAccountNr() : string
    {
        return $this->accountNumber;
    }
    public function SetAccountNr($accountNumber)
    {
        $this->accountNumber = $accountNumber;
    }
    public function GetDepartment() : string
    {
        return $this->department;
    }
    public function IsContractFixed() : bool
    {
        return $this->contractFixed;
    }
    public function GetContractHours() : int
    {
        return $this->workHours;
    }
    public function IsOnNightShifts() : bool
    {
        return $this->nightShifts;
    }
    public function SetNightShifts(bool $nightShifts) : bool
    {
        $this->nightShifts = $nightShifts;
    }
    public function GetDaysOff()
    {
        return $this->daysOff;
    }
    public function SetDaysOff($daysOff)
    {
        $this->daysOff = $daysOff;
    }

    public function __construct(int $id = 0,string $email,string $username,string $firstName,
     string $lastName, string $street, int $streetNr, string $zipcode,
      string $city ,string $password, $birthDate, $hireDate, $lastWorkingDay, 
      float $wage, string $accountNumber, string $department, bool $contractFixed,
      int $workHours, bool $nightShifts,array $daysOff)
    {
        $this->id = $id;
        $this->email = $email;
        $this->username = $username;
        $this->firstName = $firstName;
        $this->lastName = $lastName;
        $this->street = $street;
        $this->streetNr = $streetNr;
        $this->zipcode = $zipcode;
        $this->city = $city;
        $this->password= $password;
        $this->$birthDate = $birthDate;
        $this->$hireDate = $hireDate;
        $this->$lastWorkingDay = $lastWorkingDay;
        $this->$wage = $wage;
        $this->$accountNumber = $accountNumber;
        $this->$department = $department;
        $this->$contractFixed = $contractFixed;
        $this->$workHours = $workHours;
        $this->$nightShifts = $nightShifts;
        foreach($daysOff as $var){
            array_push($this->daysOff,$var);
        }
    }

}
?>