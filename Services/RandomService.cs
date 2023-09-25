namespace ProvaPub.Services
{
	public class RandomService
	{
        private Random random;
		public RandomService()
		{
            int seed = new Random().Next();
            random = new Random(seed);
        }
		public int GetRandom()
		{
            return random.Next(100);
        }

	}
}
