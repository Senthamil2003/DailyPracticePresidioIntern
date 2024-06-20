const data = [
  { name: "John", mail: "John@gmail.com", Password: "123456" },
  { name: "Dan", mail: "dan@gmail.com", Password: "234567" },
];
function HandleSubmit(e) {
  e.preventDefault(); // Prevent the default form submission
  CheckUser(); // Call the function to check the user
}

var result = document.getElementById("isSuccess");
function CheckUser() {
  var mail = document.getElementById("mail").value;
  var password = document.getElementById("password").value;

  var checkValid = 0;
  data.forEach((element) => {
    if (element.mail == mail && element.Password == password) {
      checkValid = 1;
      return;
    }
  });
  if (checkValid == 1) {
    result.innerHTML = "Valid User";
  } else {
    result.innerHTML = "Invalid User";
  }
}
