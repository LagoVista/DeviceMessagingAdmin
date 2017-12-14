using LagoVista.IoT.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceMessaging.Admin.Resources
{
    public class DeviceMessagingAdminErrorCodes
    {

        public static ErrorCode CouldNotDetermineDeviceId { get { return new ErrorCode() { Code = "DMA1001", Message = "Content Type is required for Message Id and Field Id Parsers" }; } }


        public static ErrorCode CouldNotLoadDeviceMessageDefinition { get { return new ErrorCode() { Code = "SLN4001", Message = "Could Not Load Device Message Definition" }; } }

        public static ErrorCode CouldNotLoadUnitSet { get { return new ErrorCode() { Code = "SLN4002", Message = "Could Not Load Unit Set on Message" }; } }

        public static ErrorCode CouldNotLoadStateSet { get { return new ErrorCode() { Code = "SLN4003", Message = "Could Not Load State Set on Message" }; } }
    }
}
