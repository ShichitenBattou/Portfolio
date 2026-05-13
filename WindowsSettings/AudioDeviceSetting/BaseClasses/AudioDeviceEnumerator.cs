using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDeviceSetting
{
    public class AudioDeviceEnumerator : IEnumerator<AudioDevice>
    {
        private List<AudioDevice> _list;
        private int _cursor;

        public AudioDevice Current {
            get {
                if ((_cursor < 0) || (_cursor == _list.Count)){
                    throw new InvalidOperationException();
                }
                return (AudioDevice)_list[_cursor];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if ((_cursor < 0) || (_cursor == _list.Count))
                {
                    throw new InvalidOperationException();
                }
                return _list[_cursor];
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if(this._cursor < _list.Count)
            {
                this._cursor++;
            }
            return (!(this._cursor == this._list.Count));
        }

        public void Reset()
        {
            _cursor = -1;
        }

        public AudioDeviceEnumerator(List<AudioDevice> list)
        {
            this._cursor = -1;
            this._list = list;
        }

    }
}
