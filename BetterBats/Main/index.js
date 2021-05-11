function GetUser(email) {

    let xhr = new XMLHttpRequest();
    xhr.open('GET', 'https://localhost:44317/api/User/get/' + email, true);

    xhr.onreadystatechange = function() {
        // In local files, status is 0 upon success in Mozilla Firefox
        if (xhr.readyState === xhr.DONE) {
            var status = xhr.status;
            if (status === 0 || (status >= 200 && status < 400)) {
                // The request has been completed successfully
                console.log(status);
                // console.log(xhr.responseText);
                return JSON.parse(xhr.responseText)
            } else {
                console.log(status);
                // Oh no! There has been an error with the request!
            }
        }

    }

    xhr.setRequestHeader("Content-type", "application/json");

    xhr.send(email);

}

function SignIn() {

    let user = {};

    user.email = document.querySelector("#email1").value;
    user.password = document.querySelector("#password1").value;

    let xhr = new XMLHttpRequest();

    xhr.open('POST', 'https://localhost:44317/api/User/signin/', true);

    xhr.onreadystatechange = function() {
        if (xhr.readyState === xhr.DONE) {
            var status = xhr.status;
            if (status === 0 || (status >= 200 && status < 400)) {
                // The request has been completed successfully
                console.log(status);
                const userIn = JSON.parse(xhr.responseText);

                localStorage.setItem("UserId", userIn.id);
                localStorage.setItem("name", userIn.name);
                localStorage.setItem("email", userIn.email);
                localStorage.setItem("password", userIn.password);
                localStorage.setItem("UserType", userIn.type);
                localStorage.setItem("UserLocationId", userIn.locationId);

                if (userIn.type == 0) {
                    //If successful login and user.type == customer
                    window.location = "../Customer/customer.html";
                } else if (userIn.type == 1) {
                    //If successful login and user.type == manager
                    window.location = "../Manager/manager.html";
                } else {
                    alert("Invalid username or password");
                }

            } else {
                console.log(status);
                // Oh no! There has been an error with the request!
            }
        }

    }
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.send(JSON.stringify(user));


    // let userIn = GetUser(user.email);

    // let xhr = new XMLHttpRequest();

    // xhr.onload = function() {
    //     if (xhr.status === 200)
    //         responseObject = JSON.parse(xhr.responseText);

    //     const userObject = GetUser(responseObject.email);


    //     localStorage.setItem("UserId", userObject.id);
    //     localStorage.setItem("name", userObject.name);
    //     localStorage.setItem("email", userObject.email);
    //     localStorage.setItem("password", userObject.password);
    //     localStorage.setItem("UserType", userObject.type);
    //     localStorage.setItem("UserLocationId", userObject.locationId);

    //     if (signedInUser.type == 0) {
    //         //If successful login and user.type == customer
    //         window.location = "../customers/customer.html";
    //     } else if (signedInUser.type == 1) {
    //         //If successful login and user.type == manager
    //         window.location = "../Manager/Dashboard.html";
    //     } else {
    //         console.log("failed again");
    //     }




    // }

    // xhr.open('POST', 'http://localhost:49867/api/User/signin', true);
    // xhr.setRequestHeader("Content-type", "application/json");
    // xhr.send(JSON.stringify(user));



}