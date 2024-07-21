var required = "S";
var others = ["A", "E", "L", "N", "R", "T"];
document.addEventListener("keydown", (event) => {
  if (event.key === "Backspace") {
    Delete();
  }
  if (event.key == "Enter") {
    Submit();
  }
});

const validWords = [
  "STERN",
  "SALTER",
  "STEAL",
  "LEAST",
  "STARE",
  "SLANT",
  "ARREST",
  "STREAM",
  "RESENT",
  "STALER",
];

function fillletter() {
  var tiles = document.querySelectorAll(".tile");
  tiles.forEach((element, i) => {
    if (i == 0) {
      element.innerText = required;
    } else {
      element.innerText = others[i - 1];
    }
    element.addEventListener("click", () => write(element.innerHTML));
  });
}

function write(data) {
  var input = document.getElementById("wrod");
  input.value = input.value += data;
}
function Submit() {
  var input = document.getElementById("wrod");
  if (validWords.includes(input.value.toUpperCase())) {
    var ulitem = document.getElementById("result");
    let listItem = document.createElement("li");
    listItem.textContent = input.value.toUpperCase();
    ulitem.appendChild(listItem);
    document.getElementById("comment").innerText = "correct guess";
  } else {
    document.getElementById("comment").innerText = "wrong  guess";
  }
  setTimeout(() => {
    document.getElementById("comment").innerText = "";
  }, 1000);
  input.value = "";
}
function Delete() {
  var input = document.getElementById("wrod");
  input.value = input.value.slice(0, -1);
}
function Shuffle() {
  for (let i = others.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [others[i], others[j]] = [others[j], others[i]];
  }
  fillletter();
}
fillletter();
