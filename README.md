# SportsResultTracker
Application that scrapes for Sports Results and sends it formatted to an email daily.

For learning webscraping and emailing programatically. Webscraping might be more niche but is a strong tool to have when an API is not provided.
Sending emails is an integral part of companies and as such being able to do so programatically and on a schedule is invaluable.

## Requirements
- [x] This is an application where you should read sports data from a website once a day and send it to a specific e-mail address.
- [x] You don't need any interaction with the program. It will be a service that runs automatically.
- [x] The data should be collected from the Basketball Reference Website in the resources area.
- [x] You should use the Agility Pack library for scrapping.

## Features
### SportsResultTracker
- Simple StatsScraperService that scrapes a table from the referenced website https://www.basketball-reference.com/boxscores/
- EmailService class that configures email adressess and authorization for sending Emails (As of may 30th 2022, gmail will stop supporting sending emails this way).
- BasketballStatsModel that models the incoming data to an object. All properties hold strings for ease of use.

### SportsWorker
- A background task service that schedules daily email calls.
  - Uses Coravel library to trivialize the writing of scheduling logic.
- ProcessTimer class that invokes the SportsResultTracker when scheduled

## Challenges

- Taking in the correct Html tags so that you have access to the data in a divided manner for mapping.
- Formatting the Email service with the correct data was quite tricky.
- Finding a way to send the email in a neatly formatted way. I found a way that uses a Html template that you take in as a string and then replace a chosen phrase with. This lets you interpolate your object values inside whatever html tag you want and then insert it into the template string
- Creating a scheduler felt like a daunting task since it revolves a whole new project template. In the end the implementation i used was very simple as Coravel takes care of the scheduling logic.

## What i learned

- How a webscraper works and how to implement it
- How to send emails programatically
- Basics of background tasks 

### I would like to thank Pablo and the great community, The C# Academy, he is building over on Discord and the well crafted Projects he provides through his website
Website: https://www.thecsharpacademy.com/

### Resources and links
Topics and links used for this project:
- Project page https://www.thecsharpacademy.com/sports-results/
- Html Agility Pack https://html-agility-pack.net/
- Sending Emails through Gmail SMTP https://www.c-sharpcorner.com/blogs/send-email-using-gmail-smtp
- Background task scheduling https://www.youtube.com/watch?v=vu0fxlWl0wo&ab_channel=RobertsDevTalk
