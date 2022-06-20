namespace Zoo_Project.Models.Animals.Entities
{
    public class Giraffe : Animal
    {
        private const int deathThreshold = 60;
        public Giraffe() 
            : base(deathThreshold)
        {
        }

        private bool CanMove => Health >= deathThreshold;

        public override void Starve(int value)
        {
            if (!CanMove)
            {
                base.Starve(value);
                return;
            }

            Health -= value;
        }
    }
}
