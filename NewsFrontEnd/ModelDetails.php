<?php include('includes/header1.php');
include('includes/values.php'); ?>
<?php include 'includes/navigation.php' ?>
<div id='right-panel' class='right-panel'>
  <?php include 'includes/top-header.php' ?>

  <div class='row'>
    <div class='col-lg-12'>
      <h2 class='pageheaderFile'>MODELDETAILS</h2>
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
          document.getElementById('updateVehicleid').value = firstRow;
          document.getElementById('updateFeatures').value = rowlist[1];
          document.getElementById('updateModelDescription').value = rowlist[2];
          document.getElementById('tab3').click();
        }

        function insert() {
          var settings = {
            'url': '' + url + 'API/ModelDetailsInsert/Insert',
            'method': 'POST',
            'timeout': 0,
            'headers': {
              'Content-Type': 'application/json',
              'APIKey': '' + APIKey + ''
            },
            'data': JSON.stringify({
              'Vehicleid': '' + document.getElementById('insertVehicleid').value + '',
              'Features': '' + document.getElementById('insertFeatures').value + '',
              'ModelDescription': '' + document.getElementById('insertModelDescription').value + '',
            }),
          };

          $.ajax(settings).done(function(response) {
            document.getElementById('errorMessage').value = response.errorMessage;
          });
        }

        function update() {
          var settings = {
            'url': '' + url + 'API/ModelDetailsUpdate/Update',
            'method': 'POST',
            'timeout': 0,
            'headers': {
              'Content-Type': 'application/json',
              'APIKey': '' + APIKey + ''
            },
            'data': JSON.stringify({
              'Vehicleid': '' + document.getElementById('updateVehicleid').value + '',
              'Features': '' + document.getElementById('updateFeatures').value + '',
              'ModelDescription': '' + document.getElementById('updateModelDescription').value + '',
            }),
          };

          $.ajax(settings).done(function(response) {
            document.getElementById('errorMessage').value = response.errorMessage;
          });
        }

        function Delete(id) {
          var settings = {
            'url': '' + url + 'API/ModelDetailsDelete/Delete',
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
          'url': '' + url + 'API/ModelDetailsSelect/Select',
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
            cell.innerHTML = array[i].Vehicleid;
            var cell = newRow.insertCell(1);
            cell.innerHTML = array[i].Features;
            var cell = newRow.insertCell(2);
            cell.innerHTML = array[i].ModelDescription;
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
                    <table class='table' id='table'>
                      <thead class='thead-dark'>
                        <tr>
                          <th scope='col'>Vehicleid</th>
                          <th scope='col'>Features</th>
                          <th scope='col'>ModelDescription</th>
                        </tr>
                      </thead>
                      <tbody>

                      </tbody>
                    </table>

                  </form>
                </div>
              </div>
              <div class='tab-pane' id='tabs-2' role='tabpanel'>
                <div class='hero__tab__form'>
                  <h2>Insert</h2>
                  <form action='' method='post' class='form-group' enctype='multipart/form-data'>
                    <div class='form-group'><label for='Vehicleid'>Vehicleid</label><input type='text' id='insertVehicleid' name='insertVehicleid' class='form-control'> </div>
                    <div class='form-group'><label for='Features'>Features</label><input type='text' id='insertFeatures' name='insertFeatures' class='form-control'> </div>
                    <div class='form-group'><label for='ModelDescription'>ModelDescription</label><input type='text' id='insertModelDescription' name='insertModelDescription' class='form-control'> </div><button type='button' class='site-btn' id='InsertRcord' name='InsertRcord' onclick='insert()' value='Search'>Submit</button>
                  </form>
                </div>
              </div>
              <div class='tab-pane' id='tabs-3' role='tabpanel'>
                <div class='hero__tab__form'>
                  <h2>Update</h2>
                  <form action='' method='post' class='form-group' enctype='multipart/form-data'>
                    <div class='form-group'><label for='Vehicleid'>Vehicleid</label><input type='text' id='updateVehicleid' name='updateVehicleid' class='form-control'> </div>
                    <div class='form-group'><label for='Features'>Features</label><input type='text' id='updateFeatures' name='updateFeatures' class='form-control'> </div>
                    <div class='form-group'><label for='ModelDescription'>ModelDescription</label><input type='text' id='updateModelDescription' name='updateModelDescription' class='form-control'> </div><button type='button' class='site-btn' name='UpdateRcord' name='UpdateRcord' onclick='update()' value='Searchcash'>Submit</button>
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