using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDeviceSetting
{

    /// <summary>
    /// DeviceType
    /// </summary>
    public enum DeviceType
    {
        Playback = 0,
        Recording = 1
    }

    /// <summary>
    /// 単一のAudioDevice
    /// </summary>
    public class AudioDevice
    {
        private int _Index;
        private bool _Default;
        private bool _DefaultCommunication;
        private DeviceType _Type;
        private string _Name;
        private string _ID;
        private string _Device;

        public int Index { get { return _Index; } }
        public bool Default { get { return _Default; } set{ this._Default = value; } }
        public bool DefaultCommunication { get { return _DefaultCommunication; } }
        public DeviceType Type { get { return _Type; } }
        public string Name { get { return _Name; } }
        public string ID { get { return _ID; } }
        public string Device { get { return _Device; } }

        public AudioDevice(object Index, object Default, object DefaultCommunication, object Type, object Name, object ID, object Device)
        {
            _Index = (int)Index;
            _Default = (bool)Default;
            _DefaultCommunication = (bool)DefaultCommunication;
            if ((string)Type == DeviceType.Playback.ToString()) {
                _Type = DeviceType.Playback;
            }else{
                _Type = DeviceType.Recording;
            }
            _Name = (string)Name;
            _ID = (string)ID;
            _Device = Device.ToString();
        }
    }
}
