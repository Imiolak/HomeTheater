namespace HomeTheater.Common.Driver.Audio
{
    public interface IAudioDriver
    {
        void Mute();
        void VolumeDown();
        void VolumeUp();

        void NextTrack();
        void PreviousTrack();
        void Stop();
        void PlayPause();
    }
}
