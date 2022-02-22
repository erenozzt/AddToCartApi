
## Add To Cart Project

This project is a web API created with dot net core 3.1. There are endpoints in which all products are listed and there is an action to add products to the cart. The products were read from the json file because there was no database installation. The project does not require any database installation, etc. it can be lifted up without requiring. If everything goes fine then your server is running. In my case it is https://localhost:44392/swagger/index.html

The swagger interface opens when the swagger UI is installed in the project and launch as default. You can also request via Postman. Here you can reach the endpoints, take the action of adding products to the cart and list the products. when adding products to the cart, the stocks of the products are checked and added to the cart. if there is no stock in the product, the product is not going to add.

 


## API Reference

#### Get all products 

   * **AllProducts**: https://localhost:44392/api/ProductBasket/GetAllProducts
     * Method: **GET**
     * Return: Return All Products.

#### Add products to the shopping cart

   * **AddToCart**: https://localhost:44392/api/ProductBasket/AddtoCart
     * Method: **POST**
     * JSON Body With example:
       ```
        {
            "productId": 6,
            "Quantity": 5
        }
       ```
     * Return: Success Or Fail Messages.
     
## Screenshots

![App Screenshot](https://i.ibb.co/SDkFqRZ/image.png)

![App Screenshot](https://i.ibb.co/4f5dhPR/image.png)

![App Screenshot](https://i.ibb.co/ypVStwV/image.png)


## Authors

- [@erenozzt](https://github.com/erenozzt)


## Feedback

If you have any feedback, please reach out to us at erenozzt@gmail.com


## 🔗 Links
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/erenozzt/)
