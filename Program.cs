using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiClient
{
  class Program
  {
    private static async Task GetOneJokeByTypeAsync(string type)
    {
      try
      {
        var client = new HttpClient();
        var url = $"https://official-joke-api.appspot.com/jokes/{type.ToLower()}/random";

        var responseAsStream = await client.GetStreamAsync(url);

        var resp  = await JsonSerializer.DeserializeAsync<List<Joke>>(responseAsStream);

        var joke = resp[0];

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
    catch (HttpRequestException)
    {
      Console.WriteLine("That Theme does not exist!");
    }
  }

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
        Console.WriteLine("Choose if you want a (R)andom joke, or one of a certain (T)ype, or to (Q)uit.");
        Console.WriteLine("--------------------");
        var choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
          case "Q":
            Console.WriteLine("Good bye!");
            running = false;
            break;

          case "R":
            await GetOneRandomJokeAsync();
            break;

          case "T":
            Console.Write("Theme: ");
            var theme = Console.ReadLine();
            await GetOneJokeByTypeAsync(theme);
            break;
        }
      }
    }
  }
}
