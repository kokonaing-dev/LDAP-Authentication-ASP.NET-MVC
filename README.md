# LDAP-Authentication-ASP.NET-MVC

An ASP.NET MVC project demonstrating LDAP authentication. This project uses a test LDAP server to authenticate users based on their credentials.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Usage](#usage)
- [Contributing](#contributing)


## Introduction

This project showcases how to implement LDAP authentication in an ASP.NET MVC application. Users can log in with their credentials, which are authenticated against an LDAP server.

## Features

- LDAP authentication
- User login with username and password
- Session management

## Technologies Used

- ASP.NET MVC
- Novell.Directory.Ldap.NETStandard
- .NET 7.0
- jQuery and jQuery Validation

## Setup

### Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other compatible IDE

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/kokonaing-dev/LDAP-Authentication-ASP.NET-MVC.git
    cd LDAP-Authentication-ASP.NET-MVC
    ```

2. Open the solution in Visual Studio.

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

4. Update the `appsettings.json` file with your LDAP server settings:
    ```json
    {
      "LdapSettings": {
        "LdapServer": "ldap.forumsys.com",
        "LdapPort": 389,
        "LdapBindDn": "cn=read-only-admin,dc=example,dc=com",
        "LdapBindPassword": "password",
        "LdapBaseDn": "dc=example,dc=com"
      }
    }
    ```

5. Run the application:
    ```bash
    dotnet run
    ```

## Usage

1. Navigate to `http://localhost:5000/Account/Login` in your browser.
2. Enter a username and password from the test LDAP server:
   - Username: `einstein`
   - Password: `password`

more info about LDAP test sever => https://www.forumsys.com/2022/05/10/online-ldap-test-server/

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.


