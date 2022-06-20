namespace Zoo_Project.Models.Animals.Entities
{
    public class Monkey : Animal
    {
        private const int deathThreshold = 40;

        public Monkey() 
            : base(deathThreshold)
        {
        }
    }
}
