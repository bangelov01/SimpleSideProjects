namespace Zoo_Project.Engine
{
    using System.Reflection;

    using Zoo_Project.Models;
    using Zoo_Project.Models.Contracts;
    using static Zoo_Project.Models.Constants.DataConstants;

    public class Engine
    {
        private IZoo zoo;
        public Engine()
        {
            zoo = new Zoo(InitializeAnimals(NumberPerSpecies));
        }

        public void Run()
        {
            Console.WriteLine("Commands:\r\nFeed, Starve, GetAlive, MinHealth {AnimalName}");
            Console.WriteLine("To end type END");

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = args[0];

                switch (command)
                {
                    case "Feed":
                        zoo.FeedAnimals();
                        Console.WriteLine("Animals are fed."); break;
                    case "Starve":
                        zoo.StarveAnimals();
                        Console.WriteLine("Animals are hungry."); break;
                    case "GetAlive":
                        Console.WriteLine($"Alive animals {zoo.AliveCount()}"); break;
                    case "MinHealth":
                        bool match = zoo.Species.Contains(args[1]);
                        Console.WriteLine(match ? $"Min health is {zoo.MinimalHealth(args[1])}" : "Animal does not exist!"); break;
                    default:
                        Console.WriteLine("Invalid command!"); break;
                }
            }
        }

        private List<IAnimal> InitializeAnimals(int numberPerType)
        {
            var result = new List<IAnimal>();

            var types = Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => !t.IsAbstract && (typeof(IAnimal).IsAssignableFrom(t)))
                        .ToList();

            foreach (var type in types)
            {
                for (int i = 0; i < numberPerType; i++)
                {
                    result.Add((IAnimal)Activator.CreateInstance(type));
                }
            }

            return result;
        }
    }
}
