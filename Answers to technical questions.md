# 1. Technical Questions

## 1. How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test, use this as an opportunity to explain what you would add.

I have spent about 12 hours:
* 2 hours reading about Angular, but without having much experience with it, finally I chose .NET 6 over it
* An hour reading about .NET 6 to see the differences between this version and old Framework
* Another hour reading about how to use clean architecture with console applications
* Another 2 trying to see why my tests did not run. I deleted some nuget packages accidentally
* The rest implementing the challenge

Maybe I should have chosen Angular to get more experience with it. Even I was thinking about doing the same challenge with Angular and with .NET 6.

I would improve the user experience. I am thinking if getting all the machines in the beggining, and only show the user choice with LinQ without asking more data to the REST API, would be a better solution than asking always for the data.

Finally, it should be better to ask the user his credentials and not using the base64 directly in the code.

## 2. What was the most useful feature added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.

Not the language per se, I think, but the new Visual Studio assistance. The 2019 version was not that annoying.

## 3. How would you track down a performance issue in production? Have you ever had to do this?

After testing the code in a local version, having a large testing environment to continue testing can help with performance issues before launching new code to production.

I have had these performance issues:
* Long times getting large data from a database. We had a problem with indexes and we were not using the best query for the task.
* Parsing large chunks of json data with Vue in the background. This issue was caused due to the way data had to be shown to the user. We knew we would have performance issues in a future, but the user wanted the data that way.
* Having 32 bits version libraries installed instead of 64 bits ones.
* Generating large files, and I am talking about files of more than 1 GiB of size, or generating large PDF reports, server side.

That being said, if the user sees that the program or web is doing something, showing all the UI but the data, normally they wait without complaining. So, it is a great idea using background tasks or threads when possible, to take advantage of the system processing power.

## 4. How would you improve the Lantek API that you just used?

* Add calls with pagination.
* Add data expiration. This would let us only asking for new data to the API if the data we have is old.