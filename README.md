
# Hepsiburada Case 
- Product and category list includes endpoints.
- The product is listed with 5-minute caches with the help of redis
- Errors in the application are logged
<br/>

## Running with Docker

- Prerequisites [Docker](https://www.docker.com/)
- `git clone https://github.com/tahasvc/hepsi-case.git`
- `cd src`
- `docker-compose up --build`
- Navigate to server http://localhost:5000


## How to Use

#### Product Service
  
  * `/api/products`

   API Accepts <strong>GET</strong> request. Get product.

   Response:
```json
 {
  "_id": "b2dc7b494d9e2c75d64cc722ade4e63f",
  "name": "Döner",
  "description": "1 Porsiyon yaprak döner",
  "categoryId": {
    "_id": "10aeda2dfe374764e33eb14b208b262f",
    "name": "Türk Mutfağı",
    "description": "Türk mutfağına ait lezzetler"
  },
  "price": 25.9,
  "currency": "TL"
}
 ```
 
   * `/api/products`

   API Accepts <strong>POST</strong> request. Save product.

   Request:
```json
 {
  "_id": "b2dc7b494d9e2c75d64cc722ade4e63",
  "name": "Döner",
  "description": "1 Porsiyon yaprak döner",
  "categoryId": "10aeda2dfe374764e33eb14b208b262f",
  "price": 25.9,
  "currency": "TL"
}
 ```

   * `/api/products`

   API Accepts <strong>PUT</strong> request. Update product.

   Request:   `/api/products/b2dc7b494d9e2c75d64cc722ade4e63`
```json
 {
  "_id": "b2dc7b494d9e2c75d64cc722ade4e63",
  "name": "Döner",
  "description": "1 Porsiyon yaprak döner",
  "categoryId": "10aeda2dfe374764e33eb14b208b262f",
  "price": 25.9,
  "currency": "TL"
}
 ```
 
    * `/api/products`

   API Accepts <strong>DELETE</strong> request. Delete product.

   Request:
```
/api/products/b2dc7b494d9e2c75d64cc722ade4e63
 ```
 
   Response:
```json
true
 ```
 
 #### Category Service
 
 
   * `/api/categories`

   API Accepts <strong>GET</strong> request. Get categories.

   Response:
```json
{
  "_id": "10aeda2dfe374764e33eb14b208b262f",
  "name": "Türk Mutfağı",
  "description": "Türk mutfağına ait lezzetler"
}
```
   * `/api/categories`

   API Accepts <strong>POST</strong> request. Save categories.

   Request:
```json
{
  "name": "Türk Mutfağı",
  "description": "Türk mutfağına ait lezzetler"
}
```

   * `/api/categories`

   API Accepts <strong>PUT</strong> request. Update categories.

   Request: `/api/categories/10aeda2dfe374764e33eb14b208b262f`
```json
{
  "_id": "10aeda2dfe374764e33eb14b208b262f",
  "name": "Türk Mutfağı",
  "description": "Türk mutfağına ait lezzetler"
}
```

   * `/api/categories`

   API Accepts <strong>DELETE</strong> request. Delete categories.

   Request: 
   `/api/categories/10aeda2dfe374764e33eb14b208b262f`
   
   Response:
```json
true
```
