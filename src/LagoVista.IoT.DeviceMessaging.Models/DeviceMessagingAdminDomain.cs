// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2ce1670c9f9521faf401aaa823978054f4a9451b273726f25159b124a8cc21bf
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models.UIMetaData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin
{
    [DomainDescriptor]
    public class DeviceMessagingAdminDomain
    {
        public const string DeviceMessagingAdmin = "Device Messaging Admin";

        [DomainDescription(DeviceMessagingAdmin)]
        public static DomainDescription DeploymentAdminDescription
        {
            get
            {
                return new DomainDescription()
                {
                    Description = "A set of classes that are used for defining message types and their properties.",
                    DomainType = DomainDescription.DomainTypes.BusinessObject,
                    Name = DeviceMessagingAdmin,
                    CurrentVersion = new Core.Models.VersionInfo()
                    {
                        Major = 0,
                        Minor = 8,
                        Build = 001,
                        DateStamp = new DateTime(2016, 5, 8),
                        Revision = 1,
                        ReleaseNotes = "Initial unstable preview"
                    }
                };
            }
        }
    }
}
