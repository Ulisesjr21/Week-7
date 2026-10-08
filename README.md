# Equipment Safety Training Slideshow - Green Field Operations

## Intended User
This application is designed for **field operators, safety inspectors, and industrial trainees** undergoing qualification for green field operation equipment.

## Context
Green field sites lack existing infrastructure and present unpredictable environmental hazards. This training slideshow provides an interactive, structured safety walkthrough covering critical operational checkpoints before full-scope fieldwork begins.

## Controls
- **Next Slide / Action:** Advances the training module or confirms a safety check.
- **Previous Slide / Reset:** Steps back to re-verify an inspection criteria or re-reads instructional steps.
- **Screen Capture Helper:** Captures current progress and validation status for training evidence logs.

## Setup
1. Open `StoryGameApp.csproj` in **Visual Studio** with the **.NET desktop development** workload installed.
2. Ensure **.NET 10 SDK** is targeted.
3. Press `F5` to build and run the application in Debug mode.
4. No external NuGet packages are required.

## Code Map
- `StoryGameApp.csproj`: Project configuration enabling WPF and Windows Forms interoperability (for screen capture utilities).
- `MainWindow.xaml`: Visual layout mapping out the slideshow presentation screen, training card canvas, and interactive control bars.
- `MainWindow.xaml.cs`: Core application logic handling state transitions between inspection cards, step validation, text updates, and dynamic asset switching.
- `Assets/Images/`: Resource directory housing the training slide diagrams and equipment state PNGs.

## Tests & Results
- **Initial Inspection Validation:** Verified that missing an inspection checkpoint triggers a warning before allowing progression.
- **Calibration Checkpoint:** Confirmed numerical simulation of power-on cycles requires parameter stabilization bounds.
- **Session Evidence Test:** Screen capture engine validated to successfully capture application boundaries without exposing peripheral desktop windows.


