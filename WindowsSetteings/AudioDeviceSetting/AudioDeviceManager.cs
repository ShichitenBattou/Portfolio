using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS0234 // 型または名前空間の名前 'Automation' が名前空間 'System.Management' に存在しません (アセンブリ参照があることを確認してください)
using System.Management.Automation;
#pragma warning restore CS0234 // 型または名前空間の名前 'Automation' が名前空間 'System.Management' に存在しません (アセンブリ参照があることを確認してください)
using System.Collections.ObjectModel;

namespace AudioDeviceSetting
{
    static public class AudioDeviceManager
    {
        static public AudioDeviceCollection Get_AllAudioDevices()
        {
            AudioDeviceCollection devices = new AudioDeviceCollection();
            using (var invoker = new RunspaceInvoke())
            {
                string src = @"Get-AudioDevice -List";
                Collection<PSObject> results = invoker.Invoke(src);
                foreach (PSObject result in results)
                {
                    dynamic obj = result.BaseObject;
                    devices.Add( new AudioDevice(obj.Index, obj.Default, obj.DefaultCommunication, obj.Type, obj.Name, obj.ID, obj.Device));
                }
            }
            return devices;
        }

        static public AudioDevice Get_PlaybackDevice()
        {
            AudioDeviceCollection devices = new AudioDeviceCollection();
            using (var invoker = new RunspaceInvoke())
            {
                string src = @"Get-AudioDevice -Playback";
                Collection<PSObject> results = invoker.Invoke(src);
                if (results.Count != 1) throw new IndexOutOfRangeException();
                    dynamic obj = results[0].BaseObject;
                    return new AudioDevice(obj.Index, obj.Default, obj.DefaultCommunication, obj.Type, obj.Name, obj.ID, obj.Device);
            }
        }

        static public AudioDevice Get_RecordingDevice()
        {
            AudioDeviceCollection devices = new AudioDeviceCollection();
            using (var invoker = new RunspaceInvoke())
            {
                string src = @"Get-AudioDevice -Recording";
                Collection<PSObject> results = invoker.Invoke(src);
                if (results.Count != 1) throw new IndexOutOfRangeException();
                    dynamic obj = results[0].BaseObject;
                    return new AudioDevice(obj.Index, obj.Default, obj.DefaultCommunication, obj.Type, obj.Name, obj.ID, obj.Device);
            }
        }

    }
}
