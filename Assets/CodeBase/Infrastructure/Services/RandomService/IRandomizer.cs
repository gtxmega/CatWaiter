namespace CodeBase.Infrastructure.Services.RandomService
{
    public interface IRandomizer
    {
        int GetRandomInt(int min, int max);
        float GetRandomFloat(float min, float max);
    }
}