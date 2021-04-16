<?php
require_once('classes/annoucementscontroller.class.php');
?>
<?php
    $annoucements = new AnnoucementsController();

    foreach ($annoucements->GetAnnoucements() as $value)
    {
        $title = $value->GetTitle();
        $description = $value->GetDescription();
        
        echo '<div class="container">',
        '<form method="POST" action="phpScripts/addToShoppingCart.php">',
           '<button type="submit" class="passwordbtn">Add</button>',
           '<input type = "hidden" name = "ProductID" value ='."$ID".'>',
        '</form>',
        '<h2>',"$title",'</h2><br>',
        '<h3>',"$description",'</h3>',
        '<h4></h4>',
        '</div>';

    }

?>