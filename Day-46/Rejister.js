var isName = false;
var isPhone = false;
var isAge = false;
var isProfession = false;
var isGender = false;

function ValidateName() {
  isProduct = false;
  const regex = /\d/;
  var InputElement = document.getElementById("name");
  var text = InputElement.value;
  const containsNumber = regex.test(text);
  var spanElement = document.getElementById("span-name");
  var errorSpan = document.getElementById("error-span-name");
  console.log(containsNumber);
  if (containsNumber) {
    spanElement.innerHTML = "Name should not contains the numbers";
    errorSpan.innerHTML = "Name should not contains the numbers";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else if (text.length < 3 || text.length > 20) {
    spanElement.innerHTML =
      "Product name should be greater than 3 and less than 20";
    errorSpan.innerHTML =
      "Product name should be greater than 3 and less than 20";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else {
    spanElement.innerHTML = "Valid Product name";

    InputElement.classList.add("good-input");
    InputElement.classList.remove("error-input");
    spanElement.classList.remove("error");
    errorSpan.classList.remove("error");
    isName = true;
  }
}

function ValidatePhone() {
  isProduct = false;
  var InputElement = document.getElementById("phone");
  var text = InputElement.value;
  console.log(text);
  var spanElement = document.getElementById("span-phone");
  var errorSpan = document.getElementById("error-span-phone");

  if (text.length != 10 || Number(text) < 0) {
    spanElement.innerHTML = "Mobile number should be 10 digit";
    errorSpan.innerHTML = "Mobile number should be 10 digit";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else {
    spanElement.innerHTML = "Valid Mobile number";

    InputElement.classList.add("good-input");
    InputElement.classList.remove("error-input");
    spanElement.classList.remove("error");
    errorSpan.classList.remove("error");
    isPhone = true;
  }
}
document.getElementById("dateOfBirth").addEventListener("change", function () {
  isAge = false;
  const dob = new Date(this.value);
  const today = new Date();
  var InputElement = document.getElementById("age");
  var text = InputElement.value;
  let age = today.getFullYear() - dob.getFullYear();
  const monthDiff = today.getMonth() - dob.getMonth();

  if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())) {
    age--;
  }
  document.getElementById("age").value = age;
  var spanElement = document.getElementById("span-age");
  var errorSpan = document.getElementById("error-span-age");

  if (Number(age) < 18) {
    spanElement.innerHTML = "You age should be greater than 18";
    errorSpan.innerHTML = "You age should be greater than 18";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else {
    InputElement.classList.add("good-input");
    InputElement.classList.remove("error-input");
    spanElement.classList.remove("error");
    errorSpan.classList.remove("error");
    isAge = true;
  }
});
var professions = ["Doctor", "Nurse", "Developer", "Designer", "Actor"];
function AddDatalist() {
  const newProfessionInput = document.getElementById("AddProfession");
  const newProfessionValue = newProfessionInput.value.trim();
  isProduct = false;
  var InputElement = newProfessionInput;
  var text = InputElement.value;
  console.log(text);
  var spanElement = document.getElementById("span-profession");
  var errorSpan = document.getElementById("error-span-profession");
  const regex = /\d/;
  const containsNumber = regex.test(text);
  if (containsNumber) {
    spanElement.innerHTML = " profession should not contains the numbers";
    errorSpan.innerHTML = "profession should not contains the numbers";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else if (text.length < 3) {
    spanElement.innerHTML = "Profession should be greater than 3";
    errorSpan.innerHTML = "Profession should be greater than 3";
    errorSpan.classList.add("error");
    spanElement.classList.add("error");
    InputElement.classList.remove("good-input");
    InputElement.classList.add("error-input");
  } else {
    spanElement.innerHTML = "Valid Mobile number";
    if (
      newProfessionValue !== "" &&
      !professions.includes(newProfessionValue)
    ) {
      const datalist = document.getElementById("Profession");
      const newOption = document.createElement("option");
      newOption.value = newProfessionValue;
      datalist.appendChild(newOption);
      professions.push(newProfessionValue);
    }
    InputElement.classList.add("good-input");
    InputElement.classList.remove("error-input");
    spanElement.classList.remove("error");
    errorSpan.classList.remove("error");
    isProfession = true;
  }

  console.log(professions);
}

function CheckSubmit(){
    

}
