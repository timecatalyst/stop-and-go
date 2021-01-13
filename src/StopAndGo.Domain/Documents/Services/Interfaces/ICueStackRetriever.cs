using System.Threading.Tasks;
using Nymbus.Domain.Documents.Cues;

namespace Nymbus.Domain.Documents.Services.Interfaces
{
    public interface ICueStackRetriever
    {
        Task<CueStack> GetCueStack(string cueStackId);
    }
}
