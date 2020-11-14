using System.Threading.Tasks;
using Orleans;

namespace Grains.Abstractions
{
    public interface IHello : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}