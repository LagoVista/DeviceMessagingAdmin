using LagoVista.IoT.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Resources
{
    public class DeviceMessagingAdminErrorCodes
    {

        public static ErrorCode CouldNotDetermineDeviceId { get { return new ErrorCode() { Code = "DMA1001", Message = "Content Type is required for Message Id and Field Id Parsers" }; } }
    }
}
