using AdviceGeneratorApp.Model;

namespace AdviceGeneratorApp.Sdk.Abstractions
{
    public interface IAdviceApi
    {
        Task<Advice> GetAdvice();
    }
}
