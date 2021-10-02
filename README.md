# ChallongeNetCore

Library for making it easier to use the API challonge.com have available.


## Code exmaples.

Everything starts with the client
```CSharp
var client = new ChallongeV1Connection(Secrets.ChallongeUsername, Secrets.ChallongeApiKey);
````

List all tournaments. A subdoamin can be specified.
```Csharp
var allTournaments = await client.Tournament.IndexRequest()
                .SendAsync();
```

To create a participant in a tournament
```Csharp
var participant = await client.Participant.CreateRequest(this.tournament.Id.ToString())
                .SetName(participantName)
                .SendAsync();
```