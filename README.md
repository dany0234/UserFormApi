# UserFormApi

UserFormApi is a C# backend application that interacts with a SQL database and provides several APIs for user management.

## Features

- **User Registration**: Allows users to register by submitting a form with their details, including an image and date of birth.
- **User Retrieval**: Fetches the list of all registered users or details of a specific user by ID.
- **Data Storage**: Stores user information, including images, in a SQL database.

## Prerequisites

- .NET SDK 8.0 or later
- SQL Server

## Configuration

Ensure you have the correct settings in your `appsettings.json` file for connecting to your SQL Server database and other configurations.

## Running the Application

1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Build the project using your preferred .NET build method.
4. Run the application locally, ensuring it listens on the appropriate URL and port.
5. Access the APIs via the defined endpoints.

## API Usage

### POST /api/user

Allows you to register a new user by submitting a form with the user's details, including an image and date of birth. The date of birth should be in the `yyyy-MM-dd` format.

### GET /api/user

Retrieves a list of all registered users, ordered by the most recent.

### GET /api/user/{id}

Fetches the details of a specific user by their ID.

## Testing

An example `index.html` file is included in the `wwwroot` folder for testing the upload functionality. You can use this file to test the API endpoints by providing the required user details and image.

## Logging

The application logs all incoming requests and important actions, such as data retrieval and storage. These logs can be accessed through your preferred logging framework or service configured in the application.

## Contributing

Feel free to submit issues or pull requests if you have suggestions or improvements. Contributions are always welcome!

## License

This project is licensed under the MIT License.
