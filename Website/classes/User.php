<?php
class User
{
    private $id;
    private $email;
    private $firstName;
    private $lastName;
    private $street;
    private $streetNr;
    private $zipcode;
    private $city;
    private $password;

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

    public function __construct(int $id = 0,string $email, string $firstName, string $lastName, string $street, int $streetNr, string $zipcode, string $city , string $password)
    {
        $this->id = $id;
        $this->email = $email;
        $this->firstName = $firstName;
        $this->lastName = $lastName;
        $this->street = $street;
        $this->streetNr = $streetNr;
        $this->zipcode = $zipcode;
        $this->city = $city;
        $this->password= $password;
    }

}
?>