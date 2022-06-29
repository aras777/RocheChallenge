# RocheChallenge TODO WebAPI

This project uses specific commits convention based on conventional commits

[Type – a type of code’s changes]

feat – new functionality

fix – fix of existing functionality

ci – changes for CI process

refactor – changes in the code without new functionalities

docs – changes in the documentation only

## Useful links

https://github.com/davidfowl/CommunityStandUpMinimalAPI

https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio

## API methods description

|API|Description|Request body|Response body|
|--|--|--|--|
|GET /|Browser test, "Hello World"|None|Hello World!|
|GET /todoitems|Get all to-do items|None|Array of to-do items|
|GET /todoitems/complete|Get completed to-do items|None|Array of to-do items|
|GET /todoitems/{id}|Get an item by ID|None|To-do item|
|POST /todoitems|Add a new item|To-do item|To-do item|
|PUT /todoitems/{id}|Update an existing item|To-do item|None|
|DELETE /todoitems/{id}|Delete an item|None|None|
