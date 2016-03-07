﻿using HomeTheater.Common.Driver.Audio;
using HomeTheater.Common.Driver.Video;
using HomeTheater.Common.Input;

namespace HomeTheater.Camera.Input
{
    public class CameraInput : InputBase, IInputMethod
    {
        public CameraInput(IAudioDriver audioDriver, IVideoDriver videoDriver) : base(audioDriver, videoDriver) { }

        public bool Available => false;

        public bool Active { get; private set; }

        public string Description => "Camera";

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            Active = false;
        }

        
    }
}
