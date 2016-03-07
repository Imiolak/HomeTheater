using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;

namespace HomeTheater.Common.Input
{
    public abstract class InputBase
    {
        protected IAudioDriver AudioDriver;
        protected IVideoDriver VideoDriver;

        protected InputBase(IAudioDriver audioDriver, IVideoDriver videoDriver)
        {
            AudioDriver = audioDriver;
            VideoDriver = videoDriver;
        }
    }
}
