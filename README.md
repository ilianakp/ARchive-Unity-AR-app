# ARchive: AR App Project

**ARchive** is the thesis from MSc Architectural Computation, The Bartlett School of Architecture. This repository, is the front-end part of the thesis: an AR application developed using Unity for iOS devices. The app enables users to explore spatio-temporal archives through a mobile XR-based interface, transforming 3D scanned data into interactive knowledge.

![ARchive_app](https://github.com/ilianakp/ARchive-Unity-AR-app/assets/37414826/c985bc08-01c4-4ed9-867e-5160dc70601e)


## Practical Steps

To use the ARchive app:

1. **Install Unity3D and Vuforia Engine**: Ensure these are installed on your machine.
2. **Create an Image Target**: Generate and print an image target using Vuforia Engine. Place it in the room to be scanned.
3. **Scan the Space**: Use an iPhone 12 Pro or compatible device to scan the space at various times.
4. **Load PCL Data**: Organize scanned data into folders based on time levels, labels, and clusters.
5. **Build and Run the App**: Load temporal PCLs into the Unity project, anchor them in the physical space, connect them to UI elements, and build/run the app on your iOS device.

## Usage

1. **Launch the App**: Open the ARchive app on your iPhone or iPad.
2. **Navigate Time**: Use the time slider to move through different temporal states.
3. **Toggle Labels**: Select/deselect labels to view specific objects' past states.
4. **Switch Modes**: Toggle between Time and Object modes to explore spatial changes and track objects over time.

## Code Overview

### `MainToggle.cs`

This script manages toggling between Time and Object modes. It handles updating the UI and switching active objects based on the selected mode.

### `radialObject.cs`

This script manages the interaction with object labels in the radial menu. It handles the activation and deactivation of objects based on label selection and updates the UI accordingly.

### `FPS.cs`

This script tracks the current frame rate (FPS) of the application and logs it to the console. It's useful for performance monitoring.

### `RadialSlider.cs`

This script handles the interaction with the radial slider for navigating temporal states. It updates the displayed model and UI based on the current slider value.

### `LoadAll.cs`

This script loads all models from the Resources folder at the start of the application. It instantiates the models and prepares them for activation based on user interaction.

## References

- Papadopoulou, I. (2021). An exploration of 3D scanning as a medium to record spatial memory. [Elsevier Pure](https://adk.elsevierpure.com/en/publications/an-exploration-of-3d-scanning-as-a-medium-to-record-spatial-memor).

## Acknowledgements

Special thanks to the supervisor, Ava Fatah gen. Schieck, and technical supervisor, Sherif Tarabishy.

 ## Digital exhibition
[https://bpro2021.bartlettarchucl.com/architectural-computation/xudong-liu-iliana-papadopoulou-tengfei-zhang
](https://bpro2021.bartlettarchucl.com/architectural-computation/iliana-papadopoulou)
