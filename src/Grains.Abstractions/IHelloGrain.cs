using System.Threading.Tasks;
using Orleans;

namespace Grains.Abstractions
{
    public interface IHelloGrain : IGrainWithGuidKey
    {
        Task<string> SayHello(string greeting);
    }
}