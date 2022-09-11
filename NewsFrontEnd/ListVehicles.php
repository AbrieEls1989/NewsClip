<?php include('includes/header1.php');
include('includes/values.php'); ?>
<?php include 'includes/navigation.php' ?>
<div id='right-panel' class='right-panel'>
  <?php include 'includes/top-header.php' ?>

  <div class='row'>
    <div class='col-lg-12'>
      <h2 class='pageheaderFile'>VEHICLES</h2>
      <script>
        var url = <?php echo "'" . $_SESSION['url'] . "'";  ?>;
        var APIKey = <?php echo "'" . $_SESSION['APIKey'] . "'"; ?>;

        function Select(id) {
          var row = document.getElementById('table').rows[id].innerHTML;
          row = row.substring(0, row.indexOf('<button'));
          var rowlist = row.split('</td><td>');
          //console.log(rowlist);
          var firstRow = rowlist[0];
          firstRow = firstRow.replace('<td>', '');
          document.getElementById('updateQTY').value = firstRow;
          document.getElementById('updateMake').value = rowlist[1];
          document.getElementById('updateModel').value = rowlist[2];
          document.getElementById('tab3').click();
        }

        function insert() {
          var settings = {
            'url': '' + url + 'API/VehiclesInsert/Insert',
            'method': 'POST',
            'timeout': 0,
            'headers': {
              'Content-Type': 'application/json',
              'APIKey': '' + APIKey + ''
            },
            'data': JSON.stringify({
              'QTY': '' + document.getElementById('insertQTY').value + '',
              'Make': '' + document.getElementById('insertMake').value + '',
              'Model': '' + document.getElementById('insertModel').value + '',
            }),
          };

          $.ajax(settings).done(function(response) {
            document.getElementById('errorMessage').value = response.errorMessage;
          });
        }

        function update() {
          var settings = {
            'url': '' + url + 'API/VehiclesUpdate/Update',
            'method': 'POST',
            'timeout': 0,
            'headers': {
              'Content-Type': 'application/json',
              'APIKey': '' + APIKey + ''
            },
            'data': JSON.stringify({
              'QTY': '' + document.getElementById('updateQTY').value + '',
              'Make': '' + document.getElementById('updateMake').value + '',
              'Model': '' + document.getElementById('updateModel').value + '',
            }),
          };

          $.ajax(settings).done(function(response) {
            document.getElementById('errorMessage').value = response.errorMessage;
          });
        }

        function Delete(id) {
          var settings = {
            'url': '' + url + 'API/VehiclesDelete/Delete',
            'method': 'Delete',
            'timeout': 0,
            'headers': {
              'Content-Type': 'application/json',
              'APIKey': '' + APIKey + ''
            },
            'data': JSON.stringify({
              'DeleteId': '' + id + '',
            }),
          };

          $.ajax(settings).done(function(response) {
            document.getElementById('errorMessage').value = response.errorMessage;
          });
        }
      </script>
      <script>
        var url = <?php echo "'" . $_SESSION['url'] . "'";  ?>;
        var APIKey = <?php echo "'" . $_SESSION['APIKey'] . "'"; ?>;
        var settings = {
          'url': '' + url + 'API/VehiclesSelect/Select',
          'method': 'GET',
          'timeout': 0,
          'headers': {
            'APIKey': '' + APIKey + ''
          },
        };

        $.ajax(settings).done(function(response) {
          console.log(response);
          table = document.getElementById('table');
          var array = response;
          console.log(array.length);
          for (var i = 0; i < array.length; i++) {
            // create a new row
            //console.log('Abrie1');
            var newRow = table.insertRow();
            //console.log(array[i]);

            var cell = newRow.insertCell(0);
            cell.innerHTML = array[i].QTY;
            var cell = newRow.insertCell(1);
            cell.innerHTML = array[i].Make;
            var cell = newRow.insertCell(2);
            cell.innerHTML = array[i].Model;
            var cell = newRow.insertCell(3);
            cell.innerHTML = "<button type='button' class='site-btn' id='DeleteRcord' name='DeleteRcord' onclick='Delete(" + array[i].idAccounts + ")' value='Delete'>Delete</button>";
            var cell = newRow.insertCell(4);
            cell.innerHTML = "<button type='button' class='site-btn' id='SelectRcord' name='SelectRcord' onclick='Select(" + array[i].idAccounts + ")' value='Select'>Select/Update</button>";
          }
        });
      </script>
      <div class='col-md-4 offset-md-3'>
        <label for='Response'>Response</label>
        <input type='text' id='errorMessage' name='errorMessage' class='form-control'>
      </div>
      <div class='col-md-8 offset-md-1'>
        <div class='col-lg-12'>
          <div class='hero__tab'>
            <ul class='nav nav-tabs' role='tablist'>
              <li class='nav-item'>
                <a class='nav-link active' id='tab1' data-toggle='tab' href='#tabs-1' role='tab'>Select</a>
              </li>
              <li class='nav-item'>
                <a class='nav-link' data-toggle='tab' id='tab2' href='#tabs-2' role='tab'>Insert</a>
              </li>
              <li class='nav-item'>
                <a class='nav-link' data-toggle='tab' id='tab3' href='#tabs-3' role='tab'>Update</a>
              </li>
            </ul>
            <div class='tab-content'>
              <div class='tab-pane active' id='tabs-1' role='tabpanel'>
                <div class='hero__tab__form'>
                  <h2>Select</h2>
                  <form action='' method='post' class='form-group' enctype='multipart/form-data'>
                    <?php foreach ($Vehicles as $vehicles) : ?>
                      <div class="col-lg-3 col-md-3">

                        <div class="car__item">

                          <div class="carcard">

                            <div class="car__item__pic__slider owl-carousel">
                              <?php

                              echo  "<img src=" . $ImagesResult[$key]['ImagePath'] . " alt=''>";


                              ?>
                            </div>
                            <div class="car__item__text">

                              <div class="col-12 px-0 text-center">
                                <?php

                                $var = $vehicles->sales_status;

                                $fullname =  $vehicles->MakeName . "/" . $vehicles->ModelName . "/" . $vehicles->StockCode;
                                $fullname =   str_replace(' ', '_', $fullname);

                                if ($var == 'Finance Pending') {
                                  echo "<div class='mysaleinprogresscolor'><span>Sale In Progress</span></div>";
                                } else {
                                  echo "<a style='color:#fff !important' href='https://secondhandcars.co.za/usedcars/" . $fullname . "'><div class='myenquirenowcolor'>Enquire Now</div></a>";
                                }
                                ?>
                              </div>
                              <div class="carinfoblock">
                                <div class="col-12 text-center my-auto pricevehicle">
                                  <?php
                                  $price = str_replace(',', '.', $vehicles->VehiclePrice);

                                  $english_format_number = number_format($price, 2);
                                  ?>
                                  <h6>R<?php echo $english_format_number ?></h6>
                                </div>
                                <div class="car__item__text__inner text-center" style="height:50px;">
                                  <h5>
                                    <?php

                                    $fullname =  $vehicles->MakeName . "/" . $vehicles->ModelName . "/" . $vehicles->StockCode;
                                    $fullname =   str_replace(' ', '_', $fullname);

                                    echo "<a href='https://secondhandcars.co.za/usedcars/" . $fullname . "'>" . $vehicles->MakeName . " " . $vehicles->ModelName . "</a>";

                                    ?>
                                  </h5>
                                  <!-- <h5><?php echo $vehicles->MakeName; ?> <?php echo $vehicles->ModelName; ?> </h5> -->
                                </div>
                                <div class="row cardetailsprice">
                                  <!-- <div class="col-12 text-center my-auto pricevehicle">
                                                        <h6>R<?php echo $vehicles->VehiclePrice; ?></h6>
                                                    </div> -->
                                  <!-- <div class="col-12 text-center">or</div> -->

                                </div>
                                <div class="row mt-2 mb-2 mileagekm">
                                  <div class="col-6 text-center">
                                    <h6>Mileage</h6>
                                  </div>
                                  <div class="col-6 text-center">
                                    <h6><?php echo $vehicles->VehicleMileage; ?> KM</h6>
                                    <!-- <h6>R<?php echo $vehicles->Installment; ?> p/m
                                                        </h6> -->
                                  </div>
                                </div>
                                <div class="col-12 text-center pt-2 border-top installmentpricing">
                                  <div class="row">
                                    <div class="col-2 my-auto">
                                      60 Mos
                                    </div>
                                    <div class="col-2 my-auto">
                                      10%
                                    </div>
                                    <div class="col-8 my-auto">
                                      From R<?php echo $vehicles->Installment; ?> p/m
                                    </div>
                                  </div>

                                </div>
                                <div class="row actionbuttons">
                                  <!-- <div class="col-12 text-center">
                                                        <?php


                                                        $fullname =  $vehicles->MakeName . "/" . $vehicles->ModelName . "/" . $vehicles->StockCode;
                                                        $fullname =   str_replace(' ', '_', $fullname);

                                                        echo "<a href='https://secondhandcars.co.za/usedcars/" . $fullname . "' class='enquirynowbutton'>ENQUIRE NOW</a>";

                                                        ?>

                                                    </div> -->
                                  <div class="col-4 text-right">
                                    <!-- <a href='https://secondhandcars.co.za/dealership.php?id=<?php echo $vehicles->DealershipID; ?>'><i class="fas fa-warehouse"></i></a> -->
                                    <?php

                                    $var = $vehicles->sales_status;
                                    $fullname =  $vehicles->MakeName . "/" . $vehicles->ModelName . "/" . $vehicles->StockCode;
                                    $fullname =   str_replace(' ', '_', $fullname);


                                    if ($var == 'Finance Pending') {
                                      echo "<a href='https://secondhandcars.co.za/usedcars/" . $fullname . "' class='fas fa-eye'></a>";
                                    }
                                    ?>



                                  </div>
                                </div>

                              </div>
                            </div>

                          </div>



                        </div>

                      </div>
                    <?php endforeach; ?>

                  </form>
                </div>
              </div>


            </div>
          </div>
        </div>


      </div>



    </div>


  </div>

</div>

<?php include('includes/footer.php'); ?>