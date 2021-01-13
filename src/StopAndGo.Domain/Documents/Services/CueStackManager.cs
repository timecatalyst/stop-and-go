using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Options;
using Nymbus.Domain.Documents.Cues;
using Nymbus.Domain.Documents.Services.Interfaces;
using Nymbus.Domain.Features.Cues.Configuration;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.Documents.Services
{
    public class CueStackManager : IFeatureService, ICueStackManager
    {
        private readonly IOptions<CueDatabaseOptions> _cueDatabaseOptions;
        private readonly DocumentClient _documentClient;

        public CueStackManager (
            IOptions<CueDatabaseOptions> cueDatabaseOptions,
            DocumentClient documentClient)
        {
            _cueDatabaseOptions = cueDatabaseOptions;
            _documentClient = documentClient;
        }

        public async Task<string> CreateCueStack()
        {
            var cueStack = new CueStack
                           {
                               Id = Guid.NewGuid().ToString(),
                               CueEffectStateDuration = 1000,
                               Cues = Array.Empty<Cue>()
                           };

            return await CreateCueStack(cueStack);
        }

        public async Task<string> CreateCueStack(CueStack cueStack)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(
                _cueDatabaseOptions.Value.DatabaseName,
                CueDatabaseCollections.CueStacks);

            await _documentClient.UpsertDocumentAsync(uri, cueStack);

            return cueStack.Id;
        }

        public async Task<CueStack> GetCueStack(string cueStackId) =>
            await _documentClient.ReadDocumentAsync<CueStack>(
                UriFactory.CreateDocumentUri(
                    _cueDatabaseOptions.Value.DatabaseName,
                    CueDatabaseCollections.CueStacks,
                    cueStackId));

        public async Task DeleteCueStack(string cueStackId) =>
            await _documentClient.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri(
                    _cueDatabaseOptions.Value.DatabaseName,
                    CueDatabaseCollections.CueStacks,
                    cueStackId));

        public async Task UpdateCueStack(CueStack cueStack) =>
            await _documentClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(
                    _cueDatabaseOptions.Value.DatabaseName,
                    CueDatabaseCollections.CueStacks,
                    cueStack.Id),
                cueStack);
    }
}
