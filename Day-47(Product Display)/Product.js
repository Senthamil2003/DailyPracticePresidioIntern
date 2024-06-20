fetch("https://dummyjson.com/products")
  .then((res) => res.json())
  .then((data) => {
    var container = document.getElementById("cont");
    var element = "";
    
    data.products.forEach((product) => {
        var review=product.reviews;
   
        const averageRating = review.reduce((sum, review) => sum + review.rating, 0) / review.length;

        
        
      element += `
        <div class="card " style="width: 18rem; margin: 10px;">
          <img class="card-img-top" src="${product.thumbnail}" alt="${product.title}">
          <div class="card-body">
            <h5 class="card-title">${product.title}</h5>
            <p class="card-text">${product.description}</p>
            <p class="card-text">${product.price}</p>
            <p class="card-text">${averageRating.toFixed(1)}</p>
               
            <a href="#" class="btn btn-primary">Add to cart</a>
          </div>
        </div>
      `;
    });

    container.innerHTML = element;
  })
  .catch((error) => {
    console.error('Error fetching data:', error);
  });
