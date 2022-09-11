<?php require_once("includes/header.php");
 ?>

<?php

if(isset($_POST["submit"]))
{
	header("Location: Vehicles.php");
}


?>
<div class="login_page">
    



<div class="section group">
	<div class="collogin span_1_of_2login">

<div class="login_form deska">

</div>

	</div>
	<div class="collogin span_1_of_2login">

<div class="login_form">
<h4 class="bg-danger"></h4>
	<script src="src/index.js"></script>
<form id="login-id" action="" method="post">
	
<div class="form-group">
	<!--<label for="username">Username</label>-->
	<input type="text" class="form-control" name="username" placeholder="Username" value="" >

</div>

<div class="form-group">
	<!--<label for="password">Password</label>-->
	<input type="password" class="form-control" name="password" placeholder="Password" value="">
	
</div>


<div class="section group">
	<div class="colreg span_1_of_2reg">
	    <div class="form-group">
            <input type="submit" name="submit" value="SUBMIT" class="btn btn-dark">
        </div>
	</div>

</div>

</form>
    </div>

	</div>
</div>

</div>