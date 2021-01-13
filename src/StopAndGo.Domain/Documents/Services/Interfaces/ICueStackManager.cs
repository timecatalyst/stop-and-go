using System.Threading.Tasks;
using Nymbus.Domain.Documents.Cues;

namespace Nymbus.Domain.Documents.Services.Interfaces
{
    public interface ICueStackManager
    {
        Task<string> CreateCueStack();
        Task<string> CreateCueStack(CueStack cueStack);
        Task<CueStack> GetCueStack(string cueStackId);
        Task DeleteCueStack(string cueStackId);
        Task UpdateCueStack(CueStack cueStack);
    }
}
