using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Application = System.Windows.Application;

namespace HomeTheater.Common.Driver.Audio
{
    public class AudioDriver : IAudioDriver
    {
        private const int KEYEVENTF_EXTENTEDKEY = 1;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        private const int VK_MEDIA_STOP = 0xB2;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        
        private const uint WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public void Mute()
        {
            var handle = GetHandle();
            SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public void VolumeDown()
        {
            var handle = GetHandle();
            SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public void VolumeUp()
        {
            var handle = GetHandle();
            SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        public void NextTrack()
        {
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }

        public void PreviousTrack()
        {
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }

        public void Stop()
        {
            keybd_event(VK_MEDIA_STOP, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }

        public void PlayPause()
        {
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }

        private IntPtr GetHandle()
        {
            return new WindowInteropHelper(Application.Current.MainWindow).Handle;
        }
    }
}
