<?php
 class Contact
  {
    private $sender;
    private $topic;
    private $text;
 
    public function GetSender() : string
  {
     return $this->sender;
  }
    public function SetSender(string $sender) 
  {
    $this->$sender = $sender;
  }
  public function GetTopic() : string
  {
     return $this->topic;
  }
    public function SetTopic(string $topic) 
  {
    $this->$topic = $topic;
  }

    public function GetText() : string
  {
    return $this->text;
  }

    public function SetText(string $text)
  {
    $this->$text = $text;
  }

    public function __construct(string $sender, string $topic, string $text)
  {
  $this->sender = $sender;
  $this->topic = $topic; 
  $this->text = $text; 
  }

}
 ?>