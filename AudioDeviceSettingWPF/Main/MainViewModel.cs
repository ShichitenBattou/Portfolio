using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AudioDeviceSettingForm.Main
{
    public class MainViewModel : ViewModelBase
    {
        private CoreAudioController _controller = new CoreAudioController();
        private static readonly MainViewModel _instance = new MainViewModel();
        public static MainViewModel Instance => _instance;

        private MainViewModel()
        {
            PlaybackDevices = new ObservableCollection<CoreAudioDevice>(_controller.GetPlaybackDevices(DeviceState.Active));
            CaptureDevices = new ObservableCollection<CoreAudioDevice>(_controller.GetCaptureDevices(DeviceState.Active));
            RefreshDevicesCommand = new RelayCommand(RefreshDevices);
        }

        public ICommand RefreshDevicesCommand { get; }

        private ObservableCollection<CoreAudioDevice>? _playbackDevices;
        public ObservableCollection<CoreAudioDevice>? PlaybackDevices
        {
            get => _playbackDevices;
            set
            {
                SetProperty(ref _playbackDevices, value);
            }
        }

        private ObservableCollection<CoreAudioDevice>? _captureDevices;
        public ObservableCollection<CoreAudioDevice>? CaptureDevices
        {
            get => _captureDevices;
            set
            {
                SetProperty(ref _captureDevices, value);
            }
        }

        public void RefreshDevices()
        {
            if (PlaybackDevices != null)
            {
                var newPlaybackDevices = _controller.GetPlaybackDevices(DeviceState.Active).ToList();
                PlaybackDevices.Clear();
                foreach (var device in newPlaybackDevices)
                {
                    PlaybackDevices.Add(device);
                }
            }

            if (CaptureDevices != null)
            {
                var newCaptureDevices = _controller.GetCaptureDevices(DeviceState.Active).ToList();
                CaptureDevices.Clear();
                foreach (var device in newCaptureDevices)
                {
                    CaptureDevices.Add(device);
                }
            }
        }
    }
}
