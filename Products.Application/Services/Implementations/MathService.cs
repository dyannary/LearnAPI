namespace Products.Application.Services.Implementations
{
    public class MathService : IMathService
    {
        public List<int> Sort(List<int> toSort)
        {
            return toSort.OrderBy(x=>x).ToList();
        }
    }
}
