var skip = -5;
var authorName = "";
var allData = [];
var totalPages = 0;
var currentPage = 1;
const maxPagesToShow = 4;

window.onload = fetchAllData;

async function fetchAllData() {
  try {
    const response = await fetch(`https://dummyjson.com/quotes?limit=0`, {
      method: "GET",
    });
    const data = await response.json();
    console.log(data)
    allData = data.quotes;
    totalPages = Math.ceil(data.total / 5);
    Nextdata();
  } catch (err) {
    console.log(err);
  }
}

function filterByAuthor(author) {
  if (author.length === 0) {
    return allData;
  } else {
    return allData.filter((quote) => quote.author === author);
  }
}

function Nextdata() {
  var cont = document.getElementById("cont");
  var content = "";
  var filteredData = filterByAuthor(authorName);

  if (filteredData.length === 0) {
    content = "<p>No quotes found.</p>";
  } else {
    const startIndex = (currentPage - 1) * 5;
    const endIndex = startIndex + 5;
    filteredData.slice(startIndex, endIndex).forEach((element) => {
      content += `<div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="./Images/image1.jfif" class="card-img-top" alt="...">
                    <div class="card-body">
                      <h5 class="card-title">${element.author}</h5>
                      <p class="card-text">${element.quote}</p>
                    </div>
                  </div>
            </div>`;
    });
  }

  cont.innerHTML = content;
  renderPagination();
}

function renderPagination() {
  var pagination = document.getElementById("pagination");
  var paginationContent = "";


  paginationContent += `<button class="page-link" onclick="goToPage(1)">First</button>`;


  paginationContent += `<button class="page-link" onclick="Previousdata()">Previous</button>`;


  let startPage = Math.max(1, currentPage - Math.floor(maxPagesToShow / 2));
  let endPage = Math.min(totalPages, startPage + maxPagesToShow - 1);

  if (endPage - startPage < maxPagesToShow - 1) {
    endPage = startPage + maxPagesToShow - 1;
  }

  for (let i = startPage; i <= endPage; i++) {
    paginationContent += `<button class="page-link ${
      i === currentPage ? "active" : ""
    }" onclick="goToPage(${i})">${i}</button>`;
  }


  paginationContent += `<button class="page-link ${
    currentPage === totalPages ? "disabled" : ""
  }" onclick="goToNextPage()">Next</button>`;


  paginationContent += `<button class="page-link ${
    currentPage === totalPages ? "active" : ""
  }" onclick="goToPage(${totalPages})">Last</button>`;

  pagination.innerHTML = paginationContent;
}

function goToPage(page) {
  currentPage = page;
  skip = (page - 1) * 5 - 5;
  Nextdata();
}

function goToNextPage() {
  if (currentPage < totalPages) {
    currentPage++;
    skip = (currentPage - 1) * 5 - 5;
    Nextdata();
  }
}

function Previousdata() {
  if (currentPage > 1) {
    currentPage--;
    skip = (currentPage - 1) * 5 - 5;
    Nextdata();
  }
}

function Search() {
  authorName = document.getElementById("search").value;
  currentPage = 1;
  skip = -5;
  Nextdata();
}

