using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using Nymbus.Domain.Documents.Cues;
using Nymbus.Domain.Documents.Services.Interfaces;
using Nymbus.Domain.Features.Cues.Configuration;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.Documents.Services
{
    public class CueStackRetriever : IFeatureService, ICueStackRetriever
    {
        private readonly IOptions<CueDatabaseOptions> _cueDatabaseOptions;
        private readonly DocumentClient _documentClient;

        public CueStackRetriever(
            IOptions<CueDatabaseOptions> cueDatabaseOptions,
            DocumentClient documentClient)
        {
            _cueDatabaseOptions = cueDatabaseOptions;
            _documentClient = documentClient;
        }

        public async Task<CueStack> GetCueStack(string cueStackId) =>
            await _documentClient.ReadDocumentAsync<CueStack>(
                UriFactory.CreateDocumentUri(
                    _cueDatabaseOptions.Value.DatabaseName,
                    CueDatabaseCollections.CueStacks,
                    cueStackId));
    }
}
