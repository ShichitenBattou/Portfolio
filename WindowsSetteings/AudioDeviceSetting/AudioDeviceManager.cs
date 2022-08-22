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
    public class AudioDeviceManager
    {
        static private AudioDeviceManager _audioDeviceManager;
        private int _DefaultPlayback_ADIndex;
        private int _DefaultRecording_ADIndex;
        public AudioDeviceCollection PlaybackAudioDevices;
        public AudioDeviceCollection RecordingAudioDevices;

        private AudioDeviceManager()
        {
            PlaybackAudioDevices = new AudioDeviceCollection();
            RecordingAudioDevices = new AudioDeviceCollection();
            Get_AllAudioDevices();
        }

        static public AudioDeviceManager Get_Instance()
        {
            if (_audioDeviceManager == null) _audioDeviceManager = new AudioDeviceManager();
            return _audioDeviceManager;
        }

        public void  Get_AllAudioDevices()
        {
            using (var invoker = new RunspaceInvoke())
            {
                string src = @"Get-AudioDevice -List";
                int index;
                Collection<PSObject> results = invoker.Invoke(src);
                foreach (PSObject result in results)
                {
                    dynamic obj = result.BaseObject;
                    switch (obj.Type)
                    {
                        case "Playback":
                            index = PlaybackAudioDevices.AddDevice(new AudioDevice(obj.Index, obj.Default, obj.DefaultCommunication, obj.Type, obj.Name, obj.ID, obj.Device));
                            if (obj.Default) _DefaultPlayback_ADIndex = index;
                            break;
                        case "Recording":
                            index = RecordingAudioDevices.AddDevice(new AudioDevice(obj.Index, obj.Default, obj.DefaultCommunication, obj.Type, obj.Name, obj.ID, obj.Device));
                            if (obj.Default) _DefaultRecording_ADIndex = index;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public AudioDevice Get_PlaybackDevice()
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

        public AudioDevice Get_RecordingDevice()
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

        public void Set_AudioDevice(AudioDevice audioDevice)
        {
                using (var invoker = new RunspaceInvoke())
                {
                    string src = $@"Set-AudioDevice -ID ""{audioDevice.ID}""";
                    Collection<PSObject> results = invoker.Invoke(src);
                    foreach (PSObject pS in results)
                    {
                        Console.WriteLine(pS.ToString());
                    }
                }            
        }

        public bool Change_Device(AudioDevice audioDevice)
        {
            switch(audioDevice.Type){
                case DeviceType.Playback:
                    return Change_PlaybackDevice(audioDevice);
                case DeviceType.Recording:
                    return Change_RecordingDevice(audioDevice);
                default:
                    return false;
            }
        }

        private bool Change_PlaybackDevice(AudioDevice newDevice)
        {
            AudioDevice oldDevice = PlaybackAudioDevices[_DefaultPlayback_ADIndex];
            if (oldDevice.Equals(newDevice)) return true;
            try
            {
                Set_AudioDevice(newDevice);
                _DefaultPlayback_ADIndex = PlaybackAudioDevices.IndexOf(newDevice);
                newDevice.Default = true;
                oldDevice.Default = false;
                return true;
            }
            catch (Exception ex)
            {
                Set_AudioDevice(oldDevice);
                return false;
            }

        }

        private bool Change_RecordingDevice(AudioDevice newDevice)
        {
            AudioDevice oldDevice= RecordingAudioDevices[_DefaultRecording_ADIndex];
            if (oldDevice.Equals(newDevice)) return true;

            try
            {
                Set_AudioDevice(newDevice);
                _DefaultRecording_ADIndex = RecordingAudioDevices.IndexOf(newDevice);
                newDevice.Default = true;
                oldDevice.Default = false;
                return true;
            }
            catch (Exception ex)
            {
                Set_AudioDevice(oldDevice);
                return false;
            }
        }

    }
}
