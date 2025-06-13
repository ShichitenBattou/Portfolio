using AudioSwitcher.AudioApi.CoreAudio;
using System.Windows;
using System.Windows.Controls;

namespace AudioDeviceSettingForm.Main;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainViewModel _viewModel = MainViewModel.Instance;

    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = _viewModel;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // 作業領域（タスクバーを除いた範囲）を取得
        var workArea = SystemParameters.WorkArea;

        // ウィンドウの位置を右下に設定
        this.Left = workArea.Right - this.Width;
        this.Top = workArea.Bottom - this.Height;
    }

    private void Window_LocationChanged(object sender, EventArgs e)
    {
        // 作業領域（タスクバーを除いた範囲）を取得
        var workArea = SystemParameters.WorkArea;

        // ウィンドウが画面の左端からはみ出している場合
        if (this.Left < workArea.Left)
        {
            this.Left = workArea.Left;
        }

        // ウィンドウが画面の右端からはみ出している場合
        if (this.Left + this.Width > workArea.Right)
        {
            this.Left = workArea.Right - this.Width;
        }

        // ウィンドウが画面の上端からはみ出している場合
        if (this.Top < workArea.Top)
        {
            this.Top = workArea.Top;
        }

        // ウィンドウが画面の下端からはみ出している場合
        if (this.Top + this.Height > workArea.Bottom)
        {
            this.Top = workArea.Bottom - this.Height;
        }
    }

    private void RefreshDevices_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.RefreshDevices();
    }

    private void setAsDefaultDevice(object sender, SelectionChangedEventArgs e)
    {
        var listView = sender as ListView;
        if (listView is null) return;

        var device = listView.SelectedItem as CoreAudioDevice;
        if (device is null) return;
        device.SetAsDefault();

        _viewModel.RefreshDevices();
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        this.Topmost = checkBox?.IsChecked ?? false;
    }

    private void Minimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void Window_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // ドラッグ移動が終了した後に位置を調整
        Window_LocationChanged(sender, e);
    }
}