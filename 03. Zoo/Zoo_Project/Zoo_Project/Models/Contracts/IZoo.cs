namespace Zoo_Project.Models.Contracts
{
    public interface IZoo
    {
        IReadOnlyCollection<string> Species { get; }
        int AliveCount();

        void FeedAnimals();

        int MinimalHealth(string type);

        void StarveAnimals();
    }
}
