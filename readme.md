## Unity3D Attitude Indicator User Study

The code in this repository is the source code of my [Masters Dissertation on the evaluation of a Pseudo-Haptic Attitude Indicator](https://fenix.tecnico.ulisboa.pt/cursos/meec21/dissertacao/1128253548923895).
Below, information about the scripts used and flow of the User Study is detailed.

## Version

To edit, compile and run this project, ensure you are running the Unity3D version:

```
m_EditorVersion: 2021.3.6f1
m_EditorVersionWithRevision: 2021.3.6f1 (7da38d85baf6)
```

## Warning

The code in this repository is not the most recent code and might need fixes, though simple. Due to hardware problems on the original computer where it was developed, there may be issues/weird behaviours with the code (i.e. renamed folders or components, missing preloads or `.meta` files, settings out of tune or renamed `.cs` scripts). This will be fixed in the future, **as soon as the hard drive of the original computer has been restored.**

## Gamepad Controls and Input Actions

The controls for the user study, `InputActions.cs` were generated using [InputActions](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Actions.html) from Unity3D. Open the `InputActions.inputactions` on your Unity Project to visually explore these settings, as the script was generated automatically. Also, take a look at `SwitchActionMap.cs`.

## Overall User Study

The user study was developed in a single Unity3D scene, but the files needed for Data Persistence are available and up-to-date (thank you Jéssica). The user study aimed to compare and evaluate quantitatively two [Attitude Indicators (AI)](https://en.wikipedia.org/wiki/Attitude_indicator): the <ins>Control</ins> and <ins>Pseudo-Haptic (PH)</ins>. For this, users performed Attitude Recovery Tasks for each indicator. The study consisted of 2 parts: practice (not to confuse with trial) and test. Each user performed a practice and a test session for each indicator. Each test session consisted of 20 trials.

## Introduction

Before starting the test, users read an introduction and filled demographic questions that appeared on slides. The logic for the buttons and scores is present on `/Assets/Scripts/ButtonScripts`.

## Scripts

1. <ins> Practice Session</ins>: On the practice session, objects were present all around the user for two minutes. This session was controlled by the `PracticeScript.cs`, which initialized the Test Session after the user pressed the top right bumper.

2. <ins>Test Session</ins>: During the trials, all objects were removed. **The main and most important script of the User Study** is the `/Scripts/UserStudyScripts/TestScript.cs`, which controlled the flow of the trials of each AI, switching AI after 10 trials.

3. <ins>Data Scripts</ins>: Located inside `/Scripts/PH_Scripts/Data Scripts`, these scripts guaranteed that the resulting `.json` files were saved on ExperimentDATA folder. Take a look at these in depth while running the executable to understand the saved data.

The saved files followed this format:

```json
{
  "num": 75,
  "order": 0,
  "indType": 0,
  "age": 21,
  "underwater": 3,
  "joystick": 2,
  "teleoperation": 1,
  "indicator": 1,
  "gender": "Female",
  "pitchType": "NormalPitch",
  "indicatorChoice": "Control",
  "blocks": [
    {
      "condition": "PseudoHaptic",
      "expData": [
        {
          "trial": 1,
          "confidence": 6,
          "understand": 7,
          "frustration": 8,
          "mentalWorkload": 7,
          "physWorkload": 5,
          "trialCondition": 1,
          "trialTime": 180.833862,
          "inputTime": 16.2766113,
          "genPitch": -49,
          "genRoll": -149,
          "startAttitude": {
            "pitch": 311.0,
            "yaw": 145.02388,
            "roll": 211.0
          },
          "finalAttitude": {
            "pitch": 353.709869,
            "yaw": 145.02388,
            "roll": 0.05520094
          },
          "indicatorChoice": "",
          "pitchDifference": 6.29013062,
          "rollDifference": 0.05520094,
          "pitchDifferenceMove": 42.70987,
          "rollDifferenceMove": -210.9448,
          "joystickMove": 2143.49561
        },
        ...]
    }
    ...]
}

```

5. <ins>Attitude Rotation</ins>: Used to control the behaviour of the Control AI (developed by Jéssica Corujeira).

6. <ins>Movement, Wobble, Particle Seek</ins>: Present inside `/Scripts/PH_Scripts` responsible for: the forces applied to the body controlling the Users' POV; simulating the wobbling liquid effect on the PH AI; making the particles float towards the target placed on top of the PH AI;

## EXE File

To compile and make an executable file, navigate to **Build Settings** on Unity3D project editor. To run the program, simply execute the `UserStudy.exe` file.
