# SOAP to REST Converter

This project is a simple layered architecture application designed to demonstrate how to convert SOAP requests into REST API calls and then transform the JSON response from the REST API back into a SOAP response. The application focuses on account-related data retrieval.

## Features
- Accepts SOAP requests and parses them.
- Converts the SOAP request into a REST API call.
- Processes the JSON response from the REST API.
- Transforms the processed JSON back into SOAP format for the client.

## Technologies Used
- **.NET Framework/Core**: For backend development.
- **Newtonsoft.Json**: For JSON parsing and serialization.
- **SOAP & REST**: Protocols used for the data flow.

## Project Structure
The project follows a simple layered architecture:

```
Project
│
├── Business
│   ├── SoapToRestMiddleware.cs      # Middleware for converting SOAP to REST
│   └── AccountManager.cs            # Service layer for account data processing
│
├── DataAccess
│   └── AccountRepository.cs         # Handles data retrieval (mocked or real database)
│
├── Entities
│   └── Account.cs                   # Defines account-related entities
│
├── Web Api
│   └── Controllers
│       └── AccountController.cs     # REST API endpoint for account data

```

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/nusretyalcn/SoapToRest-Middleware.git
   ```
2. Navigate to the project directory:
   ```bash
   cd SoapToRest-Middleware
   ```
3. Open the project in Visual Studio or your preferred IDE (Rider).
4. Build the solution to restore dependencies.

## How to Use
1. Start the application from Visual Studio or via the command line.
2. Send a SOAP request to the designated endpoint (e.g., `/api/soap`).
3. The middleware converts the SOAP request into a REST API call, retrieves the data, and returns it in SOAP format.

### Example Request Flow

# Sending SOAP POST Request in Postman

Follow these steps to send a SOAP POST request using Postman:

### 1. Select the Request Type
- Choose **POST** from the dropdown menu next to the URL field.

### 2. Enter the Request URL
- In the URL field, enter your API endpoint:
  ```http
  http://your-local-host/api/Account/getall
  ```

  #### SOAP Request Body
```xml
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
                  xmlns:web="http://example.com/webservice">
    <soapenv:Header/>
    <soapenv:Body>
        <web:GetAccounts/>
    </soapenv:Body>
</soapenv:Envelope>
```
### 3. Set Headers
- Choose **POST** from the dropdown menu next to the URL field.


#### REST API Response
```json
[
    {
        "id": 2,
        "userId": 12485,
        "accountNumber": "00012366557",
        "accountType": 1,
        "balance": 500.0000,
        "createdAt": "2025-01-22T17:51:45.94",
        "updatedAt": "2025-01-22T17:51:45.94"
    },
    {
        "id": 3,
        "userId": 12486,
        "accountNumber": "00452366557",
        "accountType": 1,
        "balance": 37800.0000,
        "createdAt": "2025-01-22T17:51:45.94",
        "updatedAt": "2025-01-22T17:51:45.94"
    },
    {
        "id": 4,
        "userId": 12336,
        "accountNumber": "001942366557",
        "accountType": 2,
        "balance": 800.0000,
        "createdAt": "2025-01-22T17:51:45.94",
        "updatedAt": "2025-01-22T17:51:45.94"
    }
]
```

#### SOAP Response (Final Output)
```xml
        
<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
    <soap:Body>
        <Root>
            <Root>
                <id>2</id>
                <userId>12485</userId>
                <accountNumber>00012366557</accountNumber>
                <accountType>1</accountType>
                <balance>500</balance>
                <createdAt>2025-01-22T17:51:45.94</createdAt>
                <updatedAt>2025-01-22T17:51:45.94</updatedAt>
            </Root>
            <Root>
                <id>3</id>
                <userId>12486</userId>
                <accountNumber>00452366557</accountNumber>
                <accountType>1</accountType>
                <balance>37800</balance>
                <createdAt>2025-01-22T17:51:45.94</createdAt>
                <updatedAt>2025-01-22T17:51:45.94</updatedAt>
            </Root>
            <Root>
                <id>4</id>
                <userId>12336</userId>
                <accountNumber>001942366557</accountNumber>
                <accountType>2</accountType>
                <balance>800</balance>
                <createdAt>2025-01-22T17:51:45.94</createdAt>
                <updatedAt>2025-01-22T17:51:45.94</updatedAt>
            </Root>
        </Root>
    </soap:Body>
</soap:Envelope>
```

## Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.

## License
This project is licensed under the [MIT License](LICENSE).

## Contact
For questions or feedback, please contact [your-email@example.com](mailto:your-email@example.com).

