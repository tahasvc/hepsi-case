
# Hepsiburada Case 
- Product and category list includes endpoints.
- The product is listed with 5-minute caches with the help of redis
<br/>

## Running with Docker

- Prerequisites [Docker](https://www.docker.com/)
- `git clone https://github.com/tahasvc/hepsi-case.git`
- `cd src`
- `docker-compose up --build`
- Navigate to server http://localhost:5000


## How to Use
  
  * `/api/products`

   API Accepts <strong>GET</strong> request. Get product list.

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
