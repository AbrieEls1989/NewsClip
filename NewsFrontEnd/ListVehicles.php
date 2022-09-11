<?php include('includes/header1.php');
include('includes/values.php'); ?>
<?php include 'includes/navigation.php' ?>
<div id='right-panel' class='right-panel'>
  <?php include 'includes/top-header.php' ?>

  <div class='row'>
    <div class='col-lg-12'>
      <h2 class='pageheaderFile'>LIST VEHICLES</h2>
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
          'method': 'Post',
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

          var lenght  = array.length;
          lenght = lenght/3;
          var e = document.body;
          for (var i = 0; i < lenght; i++) {
            var row = document.createElement("div");
            row.className = "row";
            for (var x = 1; x <= v; x++) {
              var cell = document.createElement("div");
              cell.className = "gridsquare";
              cell.innerText = "<img src="+array[i].img +"alt=''></br>"+ "Availible :"+array[i].QTY +"</br>"+
              "Make :"+array[i].Make +"</br>"+
              "Model :"+array[i].Model +"</br>"+
              "View More :<a style='color:#fff !important' href='~/VehiclesDetails.php?id=" + array[i].Id + "'>Enquire Now</a></br>";
              row.appendChild(cell);
            }
            e.appendChild(row);
          }
          document.getElementById("code").innerText = e.innerHTML;


          // for (var i = 0; i < array.length; i++) {
          //   // create a new row
          //   //console.log('Abrie1');
          //   var newRow = table.insertRow();
          //   //console.log(array[i]);

          //   var cell = newRow.insertCell(0);
          //   cell.innerHTML = array[i].QTY;
          //   var cell = newRow.insertCell(1);
          //   cell.innerHTML = array[i].Make;
          //   var cell = newRow.insertCell(2);
          //   cell.innerHTML = array[i].Model;
          // }
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
              
            </ul>
            <div class='tab-content'>
              <div class='tab-pane active' id='tabs-1' role='tabpanel'>
                <div class='hero__tab__form'>
                  
                  <form action='' method='post' class='form-group' enctype='multipart/form-data'>
                  <code id="code"></code>

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