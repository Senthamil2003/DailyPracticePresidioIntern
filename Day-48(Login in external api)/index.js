document.getElementById("loginForm").addEventListener("submit", submit);
let data=localStorage.getItem("token");
var value="No Token"
if(data!=null){
  document.getElementById("token").innerText=value;

}
function submit(event) {
  event.preventDefault();

  const username = document.getElementById("username").value;
  const password = document.getElementById("password").value;

  fetch("http://localhost:5033/api/Auth/Login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email: username, password: password }),
  })
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      localStorage.setItem("token", data.accessToken);
      value=data.accessToken
      document.getElementById("token").innerText=value;
    })
    .catch((error) => {
      console.error("Error:", error);
    });
}
function GetAlldata() {
  console.log(localStorage.getItem("token"));
  fetch("http://localhost:5033/api/Admin/GetAllOrders", {
    method: "GET",
    headers: {
      Authorization: "Bearer " + localStorage.getItem("token"),
    },
  })
    .then((res) => res.json())
    .then(console.log);
}

function UpdateCart() {
  const token = localStorage.getItem("token");
  if (!token) {
    console.error("No token found in localStorage");
    return;
  }

  

  fetch("http://localhost:5033/api/Cart/UpdateCart", {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      Authorization: "Bearer " + token,
    },
    body: JSON.stringify({
      medicineId: 1,
      status: "Increase",
      quantity: 1,
    }),
  })
    .then((response) => {  
      return response.json();
    })
    .then((data) => {
      console.log(data);
    })
    .catch((error) => {
      console.error("There was a problem with the fetch operation:", error);
    });
}
