namespace Zoo_Project.Models.Animals
{
    using Zoo_Project.Models.Contracts;

    public abstract class Animal : IAnimal
    {
        private int health = 100;
        private int deathThreshold;

        protected Animal(int deathThreshold)
        {
            this.deathThreshold = deathThreshold;
        }

        public int Health
        {
            get => health;
            protected set
            {
                if (value < 0)
                {
                    health = 0;
                    return;
                }
                else if (value > 100)
                {
                    health = 100;
                    return;
                }

                health = value;
            }
        }

        public bool IsAlive { get; protected set; } = true;

        public void Eat(int health)
        {
            Health += health;
        }

        public virtual void Starve(int value)
        {
            Health -= value;

            if (health < deathThreshold)
            {
                this.IsAlive = false;
            }
        }

        public bool IsMatch(string type)
        {
            return type == GetType().Name;
        }
    }
}
