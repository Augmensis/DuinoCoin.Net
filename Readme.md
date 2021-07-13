# DuinoCoin.Net
A C# .NET 5.0 library for Duino Coin. Feel free to fork the repo and submit pull requests for any new features you want to add. Also available as a NuGet package from https://www.nuget.org/packages/DuinoCoin.Net

Please raise any bugs and features as a new Issue/Ticket so that we can map them to pull requests where necessary.

Use the `dev` branch for the latest development updates. Create a new branch from it for any new features or bug fixes. Branches will be deleted once a Merge Request has been accepted.

So far:
- A wrapper for .NET calls to the official DUCO REST API https://github.com/dansinclair25/duco-rest-api 
- Integration tests for the service to be notified of breaking changes from the API service.
- Available as a public package from Nuget https://www.nuget.org/packages/DuinoCoin.Net

TODO:
- Add better documentation
- Get it officially added to the DUCO docs
- Port the mining logic to C#, you know, for fun!
- ?
- ?
- Profit


#Usage Examples
## Server API Integration

### Quickstart
Install the latest version of `DuinoCoin.Net` NuGet package in your .NET 5.0 compatible project
```Install-Package DuinoCoin.Net -Version 1.0.1```

For a pretty minimalist example: 
- Simply create a new ServerApi object
```
var service = new ServerApi();
```
- Then await an asyncronous call to any of the endpoint services, such as `GetMiners`:
```
var miners = await service.GetMiners();
```
- Here's an example of it all together in a new console app:
```
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        public static async Task Run()
        {
            var service = new ServerApi();

            var miners = await service.GetMiners();

            foreach (var miner in miners)
                Console.WriteLine($"{miner.Key} has {miner.Value.Count} active miners");           
        }
    }
```

### Notes
The ServerApi can be overloaded with a different base server URL if needed (e.g. You have implemented your own copy of duco-rest-api).
All method calls will be made using the new base instead of the default https://server.duinocoin.com
```
var service = new ServerApi("https://someotherurl.demo");
```

It is worth noting that some of the more complicated responses are dictionaries instead of lists. For example service.GetMiners() will return a dictionary of Usernames as the key and a List<> of miners as the corresponding value.

This service should work on any platform supporting .NET 5.0, including ASP.NET Core websites, Blazor, Xamarin and anything else that pops up on the Microsoft stack.

If you need more examples or help integrating, open an issue in GitHub and I'll do what I can to help.

Cheers,

Derek
(Dezzamondo)
On behalf of Augmensis.
