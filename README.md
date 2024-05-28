# convenience-store
An application that manages a convenience store using a database (SQLServer), implemented in C# using the MVVM design pattern. \
The database uses Third Normal Form (3NF), and all executed queries are saved as stored procedures.
### **Data stored**
- products: name, barcode, category, manufacturer, expiration date (if needed)
- category: category name
- manufacturer: name, country of origin
- stock: product name, unit of measurement, quantity, supply date, base price, selling price
- users: username, password, role (Administrator or Cashier)
- receipts: receipt date, cashier, all products sold (including quantity and subtotals), total amount paid

It has two types of users, Administrator and Cashier, each with different functionalities. After successfully logging in, either the admin or cashier window opens.

### **_Administrator_**
- _**CRUD** operations_ with the following specifications:
  - delete operations are replaced with deactivating: each table has a column **IsActive** with the data type _bit_, and when executing any operations on a table, it is required that the data is active. When a delete operation is executed, it sets the bit to 0, thus making the data unusable.
  - upon adding a new stock, only the base price can be entered. The selling price is calculated using a constant VAT saved in the App.config file.
  - after adding a stock, only the selling price can be modified, provided it remains higher than the base price.
  - all entered data is validated, and errors are raised from the stored procedures if needed (invalid IDs, duplicate data, etc.)
  - a product type can appear in multiple stock entries.
  - if a product expires, all stocks that contain it will become inactive.

### **_Cashier_**
- _**Search** feature_: cashiers can search for products using the name, barcode, expiration date, category, or manufacturer.
-  _issuing & viewing **receipts**_ with the following specifications:
   - all products added to the receipt will be displayed alongside the quantity and subtotal (calculated as quantity * sellingPrice).
   - after a receipt is finalized, it cannot be modified again.
   - after selling items, the quantity of the stock will be modified. If the item sold is found in multiple stocks, then the items will be taken from the one with the oldest supply date (quantity decreases with the number of items sold).
   - if the stock's quantity becomes zero, the stock will become inactive.
