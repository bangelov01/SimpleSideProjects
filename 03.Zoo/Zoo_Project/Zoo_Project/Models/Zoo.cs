namespace Zoo_Project.Models
{
    using System.Linq;

    using Zoo_Project.Models.Contracts;
    using static Zoo_Project.Models.Constants.DataConstants;

    public class Zoo : IZoo
    {
        private readonly List<IAnimal> animals;
        private Random random;

        public Zoo(List<IAnimal> animals)
        {
            this.animals = animals;
            random = new Random();
        }

        public IReadOnlyCollection<string> Species => animals.Select(a => a.GetType().Name).Distinct().ToList().AsReadOnly();

        public int AliveCount()
            => animals
              .Where(a => a.IsAlive)
              .Count();

        public void FeedAnimals()
            => animals
                .Take((int)Math.Floor((90 / 100D) * animals.Count))
                .OrderBy(o => o.Health)
                .ToList()
                .ForEach(a => a.Eat(random.Next(EatMinRangeValue, EatMaxRangeValue)));

        public int MinimalHealth(string type)
        {
            var animalsQuerry = animals.Where(a => a.IsMatch(type) && a.IsAlive).ToList();

            if (!animalsQuerry.Any())
            {
                return 0;
            }

            return animalsQuerry.Min(a => a.Health);
        }
        public void StarveAnimals()
        {
            foreach (var type in Species)
            {
                var randValue = random.Next(StarveMinRangeValue, StarveMaxRangeValue);

                animals.Where(a => a.IsMatch(type)).ToList().ForEach(a => a.Starve(randValue));
            }
        }
    }
}
