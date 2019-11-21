using System;

namespace MsHelper.Enums {
    public class Constants {
        public const UInt16 PackageLength = 40;
    }
    public enum ConnectionState {
        Connected,
        Disconnected
    }

    public enum EventType : UInt16 {
        Info,
        Warning,
        Error,
        Debug
    };

    public enum DebugCommand : UInt16 {
        ConnectionQuery = 0xABCD,
        ConnectionQueryResponse = 0xDCBA,
        DataRequestRaw = 0x0001,
        DataRequestScaled,
        DataRequestQuaternion,
        DataRequestAccelCalibration,
        DataRequestGyroCalibration,
        DataRequestMagCalibration,
        DataSetAccelCalibration,
        DataSetGyroCalibration,
        DataSetMagCalibration,
        DataSetEulerOffset,
        DataSetAHRSConfigs,
        LoadDefaults
    }

    public enum DataSource {
        Accel,
        Gyro,
        Mag,
        Quaternion,
        Euler
    }

    public enum DataType {
        Scaled,
        Raw
    }
}