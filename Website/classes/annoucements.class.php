<?php
class Annoucements 
{
    private $title;
    private $description;
    private $postDate;


    public function GetTitle() 
    {
        return $this->title;
    }
    public function SetTitle(string $title)
    {
        $this->title = $title;
    }
    public function GetDescription() 
    {
        return $this->description;
    }
    public function SetDescription(string $description)
    {
        $this->description = $description;
    }
    
    public function GetPostDate() 
    {
        return $this->postDate;
    }
    public function SetPostDate($postDate)
    {
        $this->postDate = $postDate;
    }

    public function __construct(string $title, string $description, $postDate)
    {
        $this->title = $title;
        $this->description = $description;
        $this->postDate = $postDate;
    }
    
}
?>