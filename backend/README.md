# NashEcommerce - backend

**Quick start**:
- cd to `NashEcommerce/backend`
- Create appsettings.json and fill all nessesarry key value pair follow by `appsettings.example.json`
- run migrations and update database all contexts (`ApplicationDbContext`, `ConfigurationDb`, `PersistedGrantDb`)
  `dotnet ef migrations add init -c [context]`
  `dotnet ef database update -c [context]`
- run backend
  `dotnet run`
----
## **RESTful API**
### **Products**
Returns json data about `product`:
<code>{
productId: number,
name: string, 
price: number, 
image: string,
description: string,
rated: number,
categoryId: number 
categoryName: string, 
createdAt: string,
updatedAt: string
}</code>

* **URL**
    `GET` */api/products* - **Allow anonymous**.
    `GET` */api/products/:id*  - **Allow anonymous**.
    `POST` */api/products* - **Require Authenticated** by `ADMIN` role.
    `PUT` */api/products/:id* - **Require Authenticated** by `ADMIN` role.
    `DELETE` */api/products/:id*  - **Require Authenticated** by `ADMIN` role.

    *  **URL Params**
        `id=[integer]`

    * **Data Params** (`POST`, `PUT`)
    *form data*
    <code>{
        name: string,
        price: number,
        imageFile?: file, **//require for POST**
        image?: string,
        description: string,
        categoryId: number
    }</code>

    * **Success Response:**
    * **Code:** 200
        **Content:** `[product]`
    OR
    * **Error Response:**
    * **Code:** 404
      **Content:** `{ error : "true", message: "product :id not found" }`
    OR
    * **Error Response:**
    * **Code:** 500
      **Content:** `{ error : "true", message: "something went wrong" }`


### **Category**
Returns json data about `category`:
<code>{
    categoryId: number,
    name: string,
    image: string,
    description: string,
    products?: [product]
}</code>

* **URL**
    `GET` */api/categories* - **Allow anonymous**
    `GET` */api/categories/:id* - **Allow anonymous**
    `POST` */api/categories* - **Require Authenticated** by `ADMIN` role.
    `PUT` */api/categories/:id*  - **Require Authenticated** by `ADMIN` role.
    `DELETE` */api/category/:id*  - **Require Authenticated** by `ADMIN` role.

    *  **URL Params**
    `id=[integer]`

    * **Data Params**
     *form data*
    <code>{
        name: string,
        description: string,
        imageFile?: file, **// require for POST**
        image?: string
    }</code>

    * **Success Response:**
    * **Code:** 200
        **Content:** `[category]`
    OR
    * **Code:** 200
        **Content:** `category`
    OR
     * **Code:** 201
        **Content:** `category`
    OR
    * **Error Response:**
    * **Code:** 404
      **Content:** `{ error : "true", message: "category :id not found" }`
    OR
    * **Error Response:**
    * **Code:** 500
      **Content:** `{ error : "true", message: "something went wrong" }`

### **Order**
Returns json data about `order`:
<code>[{
    quantity: number,
    product?: [product]
}]</code>

* **URL**
    `POST` */api/orders* - **Require Authenticated** by `CUSTOMER` role.

    *  **URL Params**
    None

    * **Data Params**
     *json data*
    <code>{
        productId: number,
        quantity: number,
    }</code>

    * **Success Response:**
    * **Code:** 201
        **Content:** `[order]`

    * **Error Response:**
    * **Code:** 500
      **Content:** `{ error : "true", message: "something went wrong" }`

### **Rating**
Returns json data about rating result: `result: bool`

* **URL**
    `POST` */api/rates* - **Require Authenticated** by `CUSTOMER` role.

    *  **URL Params**
    None

    * **Data Params**
     *json data*
    <code>{
        productId: number,
        value: number,
    }</code>

    * **Success Response:**
    * **Code:** 201
        **Content:** `true || false`

    * **Error Response:**
    * **Code:** 500
      **Content:** `{ error : "true", message: "something went wrong" }`

---
## **oauth** identity server

---
## **ORM** EF core
