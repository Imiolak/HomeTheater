# Home Theater Gesture Management
HomeTheater is an application that lets you control the multimedia on your PC using hand gestures. As of now, the following actions are supported by hand gesture management:
- volume up/down
- next/previous track
- play/pause playback

Each gesture is started by closing the palm of a hand. Opening the palm ends the gesture. Do the following between closing and opening your palm to manage multimedia:
- raise hand - volume up
- lower hand - volume down
- don't move hand - play/pause
- move hand left - next track
- move hand right - previous track

## Architecture
![Architecture](http://i.imgur.com/84GfMgu.png)

Each input source (kinect not implemented, just a placeholder) uses a driver to manipulate multimedia upon detecting specific gestures. Each input source can provide input (e.g. buttons for GUIInput) and debug (e.g. camera image with detected gestures for CameraInput) panels to be displayd in GUI.

## Camera Gesture Capture
![GestureCaptrure](http://i.imgur.com/N5oxvrI.png)

Camera input is started by clicking a button in GUI. CameraInput starts CameraCapture, which passes each camera frame to the FrameInterpreter. 

FrameInterpreter is responsible for detecting hand gestures on camera frames. When gesture is detected it is drawn on a frame for debug puroposes and passed on to the GestureParser.

GestureParser uses a gesture state machine to determine start, progress and end of each gesture. If a full gesture is performed the appriopriate method from AudioDriver is called. Gesture parser also includes a simple noise cancellation mechanism so that a gesture misdetected on a single camera frame is discarded.

## State Machine
![StateMachine](http://i.imgur.com/dvu9M8t.png)

Camera capture is started in an 'Idle' state. When an open palm is detected on a frame it goes into 'Waiting For Gesture Start' state. Gesture is started when the detected palm is closed. The state changes to 'Gesture In Progress'. Gesture is ended by opening the palm. The type of performed gesture is decided based on hand movement during 'Gesture In Progress State'.

