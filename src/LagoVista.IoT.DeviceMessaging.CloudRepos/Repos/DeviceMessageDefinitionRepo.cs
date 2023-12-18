using System.Linq;
using System.Threading.Tasks;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceMessaging.CloudRepos.Repos
{
    public class DeviceMessageDefinitionRepo : DocumentDBRepoBase<DeviceMessageDefinition>, IDeviceMessageDefinitionRepo
    {
        private bool _shouldConsolidateCollections;
        public DeviceMessageDefinitionRepo(IDeviceMessagingSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyManager) :
            base(repoSettings.DeviceMessagingDocDbStorage.Uri, repoSettings.DeviceMessagingDocDbStorage.AccessKey, repoSettings.DeviceMessagingDocDbStorage.ResourceName, logger, cacheProvider, dependencyManager)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections
        {
            get
            {
                return _shouldConsolidateCollections;
            }
        }

        public Task AddDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition)
        {
            return base.CreateDocumentAsync(deviceMessageDefinition);
        }

        public Task DeleteDeviceMessageDefinitionAsync(string id)
        {
            return base.DeleteDocumentAsync(id);
        }

        public async Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id)
        {
            var doc = await GetDocumentAsync(id);
            foreach (var field in doc.Fields)
                field.ContentType = doc.ContentType;

            return doc;
        }

        public Task<ListResponse<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request)
        {
            return base.QuerySummaryAsync<DeviceMessageDefinitionSummary, DeviceMessageDefinition>(qry => qry.OwnerOrganization.Id == orgId, qry => qry.Name, request);
        }

        public Task<ListResponse<DeviceMessageDefinitionSummary>> GetSevenSegmentDeviceMessageDefinitionsForOrgAsync(string orgId, ListRequest request)
        {
            return base.QuerySummaryAsync<DeviceMessageDefinitionSummary, DeviceMessageDefinition>(qry => qry.OwnerOrganization.Id == orgId && qry.IsSevenSegementImage == true, qry => qry.Name, request);
        }

        public Task<ListResponse<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync(ListRequest request)
        {
            return base.QuerySummaryAsync<DeviceMessageDefinitionSummary, DeviceMessageDefinition>(qry => qry.IsPublic && qry.IsSevenSegementImage == true, qry => qry.Name, request);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task UpdateDeviceMessageDefinitionAsync(DeviceMessageDefinition deviceMessageDefinition)
        {
            return base.UpsertDocumentAsync(deviceMessageDefinition);
        }
    }
}
