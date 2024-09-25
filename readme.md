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

The controls for the user study, `InputActions.cs` were generated using [InputActions](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Actions.html) from Unity3D. Open the `InputActions.inputactions` on your Unity Project to visually explore these settings, as the script was generated automatically.

## Overall User Study

The user study was developed in a single Unity3D scene, but the files needed for Data Persistence are available and up-to-date (thank you Jéssica). The user study aimed to compare and evaluate quantitatively two [Attitude Indicators (AI)](https://en.wikipedia.org/wiki/Attitude_indicator): the <ins>Control</ins> and <ins>Pseudo-Haptic (PH)</ins>. For this, users performed Attitude Recovery Tasks for each indicator. The study consisted of 2 parts: practice (not to confuse with trial) and test. Each user performed a practice and a test session for each indicator. Each test session consisted of 20 trials.

## Introduction

Before starting the test, users read an introduction and filled demographic questions that appeared on slides. The logic for the buttons and scores is present on `/Assets/Scripts/ButtonScripts`.

## Scripts

1. <ins> Practice Session</ins>: On the practice session, objects were present all around the user for two minutes. This session was controlled by the `PracticeScript.cs`, which initialized the Test Session after the user pressed the top right bumper.

2. <ins>Test Session</ins>: During the trials, all objects were removed. The most important script of the User Study is the `TestScript.cs`, which controlled the flow of the trials of each AI, switching AI after 10 trials.

3. <ins>Attitude Rotation</ins>: Used to control the behaviour of the Control AI (developed by Jéssica Corujeira).

4. <ins>Movement, Wobble, Particle Seek</ins>: Responsible for: the forces applied to the body controlling the Users' POV; simulating the wobbling liquid effect on the PH AI; making the particles float towards the target placed on top of the PH AI;

5. <ins>Particle Seek</ins>:

6. <ins>Wobble</ins>:

## EXE File

To compile and make an executable file, navigate to **Build Settings** on Unity3D project editor. To run the program, simply execute the `UserStudy.exe` file.

- experimentData file (saveData script)

- JLS material e shaders
- buttons scripts, data scripts, jessy scripts, JLS scripts, PH scripts, scripts, particle seek, attitude rotation
