function printInventory() {

    let locationId = localStorage.getItem("UserLocationId");

    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function() {

        if (xhr.readyState === xhr.DONE) {
            var status = xhr.status;
            if (status === 0 || (status >= 200 && status < 400)) {

                var tbody = document.querySelector("#tbody2");
                var inventoryLocationObject = JSON.parse(xhr.responseText);
                
                
                inventoryLocationObject.forEach(element => {

                    tbody.innerHTML += 
                    `<tr >

                        <td>${element.batId}</td>
                        <td id='batCol'></td>
                        <td>${element.quantity}</td>
                        <td>${element.locationId}</td>
                    </tr>
                   `;
                });

                printProductNameToInventory();
                

            } else {
                console.log(status);
                // Oh no! There has been an error with the request!
            }
        }
    }

    xhr.open('GET', 'https://localhost:44317/api/Inventory/get/' + locationId , true);
    xhr.send();

}

function printProductNameToInventory(){
    
    let xhr1 = new XMLHttpRequest();

    xhr1.open('GET', 'https://localhost:44317/api/Bat/get' ,false );
    xhr1.onreadystatechange = function() {

        var status = xhr1.status;
        if (status === 0 || (status >= 200 && status < 400)) {
                
            var data =JSON.parse(xhr1.responseText);
            var cols = document.querySelectorAll("#batCol");
            
        
            for(var i = 0; i < cols.length; i++){

                // if (cols[i].innerHTML==''){ // temp fix. onreadystatechange runs twice for somereason

                    cols[i].innerHTML += `${data[i].product}`;
                // }
                
            }

        } else {
            console.log(status);
                // Oh no! There has been an error with the request!
        }

    }
 
    xhr1.send();

    

}

//////////////////////////////////////////////
function addToInventory(batname){

    // get request bat information 
    //Get the bat id 
    // make inventory object {"batId":, "quantity": "locationId":}
    //post request with add inventiory api https://localhost:44317/api/Inventory/add
    //    if successful append row to the table with information 



}

function addProduct(event){

    event.preventDefault();
    const formData = new FormData(event.target);
    var form = document.querySelector("#addProductForm");
    var batObj = new Object();

    const product = formData.get("inputProductName");
    const price = formData.get("inputPrice");
    const desc = formData.get("inputDesc"); 
    var type;

    if (formData.get("selectType")==="metal")
    {type = 0;}
    else{type = 1;}


    batObj = 
    {
        "product": product,
        "price": Number(price),
        "description": desc,
        "type": type,
        "locationId": Number(localStorage.getItem("UserLocationId"))

    }

    let xhr2 = new XMLHttpRequest();

    xhr2.open("POST", 'https://localhost:44317/api/Bat/add', true);

    xhr2.onreadystatechange= function(){

        
        var status = xhr2.status;
        if (status === 0 || (status >= 200 && status < 400 && status === 500)) {//500 response code for now fix bug
                console.log(xhr2.responseText);
                // addToInventory(xhr2.responseText.product);
        }
        else {
            console.log(status);
                // Oh no! There has been an error with the request!
        }
    }

    xhr2.setRequestHeader("Content-type", "application/json");
    xhr2.send(JSON.stringify(batObj));
    form.reset();

    //addToInventory(batName);
    console.log(batObj);
}