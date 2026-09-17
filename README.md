# Contours of Hidden Pain

An augmented-reality poster about chronic spinal pain and its hidden causes. Point a webcam at the printed poster and the static page opens into animated 3D — spinal structures, growing flora, and a morphing heart — layered over the physical print.

Built in Unity with Vuforia Engine image-target tracking.

![Poster](Poster.png)

## The piece

The poster traces a four-step causal chain, printed as body text on the page itself:

1. Childhood trauma triggers chronic stress responses (physiological)
2. Chronic stress affects mental health, leading to anxiety and depression (psychological)
3. Psychological and physiological issues result in poor posture and unhealthy behaviors (behavioral)
4. A lack of social support and healthcare resources exacerbates the above (social)

The AR layer is the part the print cannot hold: the spine as something that grows, deforms, and carries weight over time.

## Requirements

- **Unity 2022.3.50f1** — the project is pinned to this version in `ProjectSettings/ProjectVersion.txt`
- A webcam
- **Git LFS** — the 3D assets and the Vuforia package are stored in LFS, so a plain `git clone` without LFS will give you pointer files instead of models

```bash
git lfs install
git clone https://github.com/luvsic707/Contours-of-Hidden-Pain.git
```

## Setting up the Vuforia license key

The license key is not committed. You need a free one of your own:

1. Register at [developer.vuforia.com](https://developer.vuforia.com/) and create a free **Development** license key
2. Copy the template into place:

   ```bash
   cd FinalPoster/Assets/Resources
   cp VuforiaConfiguration.asset.example VuforiaConfiguration.asset
   ```

3. Open `VuforiaConfiguration.asset` and paste your key into the empty `vuforiaLicenseKey:` field — or set it in Unity under **Window → Vuforia Configuration**

## Running it

1. Open `FinalPoster/` in Unity 2022.3.50f1
2. Open `Assets/Scenes/SampleScene.unity`
3. Press **Play** and allow camera access when macOS asks
4. Hold `Poster.png` in front of the webcam — printed on paper or just displayed on a second screen

An Android build is included as `FinalPoster/apk1.apk` if you would rather point a phone at the poster.

## Project structure

```
Poster.png                      the print itself, 3508 × 4961
Final Project User Guide.jpg    original submission guide
FinalPoster/                    Unity project
  Assets/
    Scenes/SampleScene.unity    the AR scene: ARCamera, ImageTarget, animated content
    Flower1.fbx, Flower2.fbx    growing flora
    Janes Heart/                morphing heart model
    Hiding Pain.WAV             ambient audio
  Packages/
    com.ptc.vuforia.engine-10.27.3.tgz
```

## Notes

Vuforia 10.27.3 reports itself as deprecated on Unity 2022.3. It loads, compiles, and tracks correctly anyway — the warning in the console is expected and can be ignored.

---

Jane P · Northeastern University, Digital Media
