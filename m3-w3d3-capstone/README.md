 <p align="center" >
 <img src="http://i.imgur.com/k7ZpbL1.png" height="175" width="175">


</p>


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
![Build Status](https://travis-ci.org/anfederico/Clairvoyant.svg?branch=master)
![bitHound](https://img.shields.io/bithound/code/github/rexxars/sse-channel.svg)
![Test Coverage](https://img.shields.io/codecov/c/github/codecov/example-python.svg)
![Join the chat at https://gitter.im/github-changelog-generator/chat](https://badges.gitter.im/github-changelog-generator/chat.svg)
![Contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg)
![License](https://img.shields.io/badge/Licence-Ahmad-blue.svg)

# Module 3 C# Capstone

## Overview

Your Capstone should:

- be an MVC Web Application
- have a consistent site layout and apply CSS styling throughout
- leverage dependency injection to simplify and isolate unit tests

## What Projects Are Included w/Repository

- **Capstone.Web** - Your ASP.NET MVC Project
- **Capstone.Web.Tests** - Your Unit Tests and Integration Tests
- **Capstone.UITests** - Your Cucumber Tests (optional)

## NuGet Packages Installed
 
- **Capstone.Web**
    - Ninject
    - Ninject.MVC5

- **Capstone.Web.Tests**
    - Moq

- **Capstone.UITests**
    - Selenium.WebDriver
    - Selenium.WebDriver.ChromeDriver
    - Selenium.Support
    - SpecRun.SpecFlow




  ##  Module 3 Capstone - National Park Weather Service

You have been asked to develop a web application for the National Park Weather Service.
The requirements for your application are listed below:
- 1. As a user of the system, I need the ability to view a list of all national parks from the home page.
a. The home page should only show a picture of the park, its name, location, and a short
summary,
- 2. As a user of the system, I need the ability select a park and view additional details about the selected
park. All detail described in the Park Data Source needs to be displayed.
- - **Capstone.Web**
    - 3. As a user of the system, once I select a park for viewing I have a way of viewing  its 5-day weather forecast. Each daily forecast should provide a recommendation so that the user knows how to prepare for the weather appropriately.
    - a. This may be on the same page as the park detail or on a separate page.
    - b. The forecast for each park can be obtained from the Weather Forecast database table.
    - c. If the daily forecast calls for snow, then tell the user to pack snowshoes.
    - d. If the daily forecast calls for rain, then tell the user to pack rain gear and wear            waterproof shoes.
    - e. If the daily forecast calls for thunderstorms, tell the user to seek shelter and avoid hiking  on exposed ridges.
    - f. If the daily forecast calls for sun, tell the user to pack sunblock.
     - g. If   the temperature is going to exceed 75 degrees, tell the user to bring an extra gallon of water.
    - h. If the difference between the high and low temperature exceeds 20 degrees, tell the user to wear   breathable layers.
    - i. If the temperature is going to be below 20 degrees, make sure to warn the user of the dangers
    of exposure to frigid temperatures.
- 4. As a user of the system, I need the ability to change my temperature preference to Celsius or
Fahrenheit. My choice should be remembered while browsing the rest of the website.
- 5. As a user of the system, I need the ability to participate in the daily survey.