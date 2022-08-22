using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDeviceSetting
{
    public class AudioDeviceCollection : ICollection<AudioDevice>
    {
        private List<AudioDevice> _list = new List<AudioDevice>();

        public int Count => _list.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        [Obsolete("このメソッドの使用は不可。\nAddDeviceを使用すること。",true)]
        public void Add(AudioDevice item)
        {
            _list.Add(item);
        }

        public int AddDevice(AudioDevice item)
        {
            _list.Add(item);
            return _list.Count - 1;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(AudioDevice item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(AudioDevice[] array, int arrayIndex)
        {
            foreach(var obj in this._list)
            {
                array.SetValue(obj, arrayIndex);
                arrayIndex++;
            }
        }

        public IEnumerator<AudioDevice> GetEnumerator()
        {
            return new AudioDeviceEnumerator(_list);
        }

        [Obsolete("このメソッドの使用は不可。",true)]
        public bool Remove(AudioDevice item)
        {
            if (item.Default) throw new Exception();
            this._list.Remove(item);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public AudioDevice this[int index]
        {
            get { return _list[index]; }
        }

        public AudioDeviceCollection GetPlaybacks()
        {
            AudioDeviceCollection playbackDevices = new AudioDeviceCollection();

            foreach (AudioDevice device in _list)
            {
                if (device.Type == DeviceType.Playback) playbackDevices.AddDevice(device);
            }
            return playbackDevices;
        }

        public AudioDeviceCollection GetRecordings()
        {
            AudioDeviceCollection playbackDevices = new AudioDeviceCollection();

            foreach (AudioDevice device in _list)
            {
                if (device.Type == DeviceType.Recording) playbackDevices.AddDevice(device);
            }
            return playbackDevices;
        }

        public int IndexOf(AudioDevice audioDevice)
        {
            return _list.IndexOf(audioDevice);
        }
    }
}
