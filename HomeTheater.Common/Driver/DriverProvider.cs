using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;

namespace HomeTheater.Common.Driver
{
    public static class DriverProvider
    {
        public static IAudioDriver GetAudioDriver()
        {
            return new AudioDriver();
        }

        public static IVideoDriver GetVideoDriver()
        {
            return new NullVideoDriver();
        }
    }
}
