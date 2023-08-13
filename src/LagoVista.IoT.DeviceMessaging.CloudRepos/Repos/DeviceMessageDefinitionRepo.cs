using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceMessaging.Admin.Repos;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.Logging.Loggers;

namespace LagoVista.IoT.DeviceMessaging.CloudRepos.Repos
{
    public class DeviceMessageDefinitionRepo : DocumentDBRepoBase<DeviceMessageDefinition>, IDeviceMessageDefinitionRepo
    {
        private bool _shouldConsolidateCollections;
        public DeviceMessageDefinitionRepo(IDeviceMessagingSettings repoSettings, IAdminLogger logger) : base(repoSettings.DeviceMessagingDocDbStorage.Uri, repoSettings.DeviceMessagingDocDbStorage.AccessKey, repoSettings.DeviceMessagingDocDbStorage.ResourceName, logger)
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

        public Task<DeviceMessageDefinition> GetDeviceMessageDefinitionAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetDeviceMessageDefinitionsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.OwnerOrganization.Id == orgId);

            return from item in items
                   select item.CreateSummary();
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetSevenSegmentDeviceMessageDefinitionsForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(qry => qry.OwnerOrganization.Id == orgId && qry.IsSevenSegementImage == true);

            return from item in items.OrderBy(msg=>msg.Name)
                   select item.CreateSummary();
        }

        public async Task<IEnumerable<DeviceMessageDefinitionSummary>> GetPublicDeviceMessageDefinitionsAsync()
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true);

            return from item in items.OrderBy(msg=>msg.Name)
                   select item.CreateSummary();
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
