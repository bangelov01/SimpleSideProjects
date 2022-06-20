namespace Zoo_Project.Models.Animals.Entities
{
    public class Bear : Animal
    {
        private const int deathThreshold = 60;
        public Bear() 
            : base(deathThreshold)
        {
        }
    }
}
