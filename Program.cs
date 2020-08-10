using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiClient
{
  class Program
  {
    private static async Task GetOneRandomJokeAsync()
    {
      var client = new HttpClient();

      var url = "https://official-joke-api.appspot.com/random_joke";

      var responseAsStream = await client.GetStreamAsync(url);

      var joke = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);

      Console.WriteLine($"Here is your {joke.Type} joke!");
      Console.WriteLine("--------------------");
      Console.WriteLine(joke.Setup);
      System.Threading.Thread.Sleep(333);
      Console.WriteLine("...");
      System.Threading.Thread.Sleep(333);
      System.Threading.Thread.Sleep(333);
      Console.WriteLine("...");
      System.Threading.Thread.Sleep(333);
      System.Threading.Thread.Sleep(333);
      Console.WriteLine("...");
      System.Threading.Thread.Sleep(333);
      Console.WriteLine(joke.Punchline);
      System.Threading.Thread.Sleep(333);
      Console.WriteLine("--------------------");
      Console.WriteLine($"I hope you enjoyed it, that was joke #{joke.Id}");
    }

    static async Task Main(string[] args)
    {
      var running=true;

      while (running)
      {
        Console.WriteLine("Choose if you want a (R)andom joke, or one of a certain (T)ype, or (Q)uit.");

        var choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
          case "Q":
            running = false;
            break;
          case "R":
            await GetOneRandomJokeAsync();
            break;
        }
      }
    }
  }
}
