namespace Zoo_Project.Models.Contracts
{
    public interface IAnimal
    {
        int Health { get; }

        bool IsAlive { get; }

        void Eat(int health);

        void Starve(int value);

        bool IsMatch(string type);
    }
}
