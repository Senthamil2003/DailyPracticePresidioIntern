var isProduct = false;
var isQuantity = false;
var isPrice = false;

function AddData(e) {
  console.log("hello", isPrice, isProduct, isQuantity);
  if (isPrice && isQuantity && isProduct) {
    let tableBody = document.getElementById("t-body");
    let inputarray = document.querySelectorAll(".form-control");
    var rowCount = tableBody.children.length;
    let tableRow = document.createElement("tr");
    var TableElement = document.createElement("td");
    var textData = document.createTextNode(rowCount + 1);
    TableElement.appendChild(textData);
    tableRow.appendChild(TableElement);
    inputarray.forEach((element) => {
      var TableElement = document.createElement("td");
      var textData = document.createTextNode(element.value);
      TableElement.appendChild(textData);
      tableRow.appendChild(TableElement);
      element.value = "";
    });
    tableBody.appendChild(tableRow);
  } else {
    alert("enter valid input");
  }
  
}

function ValidateProductName() {
    isProduct = false;
  const regex = /\d/;
  var text = document.getElementById("Product-name").value;
  const containsNumber = regex.test(text);
  var spanElement = document.getElementById("span-product");
  console.log(containsNumber);
  if (containsNumber) {
    spanElement.innerHTML = "Product name should not contains the numbers";
    spanElement.classList.add("error");
    spanElement.classList.remove("good");
  } else if (text.length < 3) {
    spanElement.innerHTML = "Product name should be greater than 3";
    spanElement.classList.add("error");
    spanElement.classList.remove("good");
  } else {
    spanElement.innerHTML = "Valid Product name";
    spanElement.classList.add("good");
    spanElement.classList.remove("error");
    isProduct = true;
  }
}
function ValidatePrice() {
    isPrice = false;
  var text = document.getElementById("price").value;
  var spanElement = document.getElementById("span-price");
  console.log(Number(text));
  if (Number(text) <= 0) {
    spanElement.innerHTML = "Price should  greater than zero";
    spanElement.classList.add("error");
    spanElement.classList.remove("good");
  } else {
    spanElement.innerHTML = "Valid Quantity";
    spanElement.classList.add("good");
    spanElement.classList.remove("error");
    isPrice = true;
  }
}
function ValidateQuantity() {
    isQuantity = false;
  var text = document.getElementById("Quantity").value;
  var spanElement = document.getElementById("span-quantity");
  console.log(Number(text));
  if (Number(text) <= 0) {
    spanElement.innerHTML = "Quantity should greater than zero";
    spanElement.classList.add("error");
    spanElement.classList.remove("good");
  } else {
    spanElement.innerHTML = "Valid Quantity";
    spanElement.classList.add("good");
    spanElement.classList.remove("error");
    isQuantity = true;
  }
}
