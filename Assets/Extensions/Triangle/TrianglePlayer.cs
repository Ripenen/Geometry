namespace Extensions.Triangle
{
    public class TrianglePlayer
    {
        public TrianglePlayer(int energy)
        {
            Energy = energy;
        }
    
        public int Energy { get; private set; }

        public void DecreaseEnergy() => Energy -= 1;
    }
}