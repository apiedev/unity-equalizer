# Unity Lighting and Effect Equalizer

## About

I initially made this script with the help of [this]() post. The files for the Audio Analyzer will also be included. It is currently being used for my upcoming Cyberpunk Rogue-Like. It allows lighting components, effects, and anything else with float values to be equalized with the scene music/sound. 

If you use this script for a project and/or game, let me know! I will add a link in this README directing people to your project page!

Any help making this script better will be greatly appreciated!

### Example of the Script

[![Scape Rogue-Like](http://img.youtube.com/vi/4N8u5OHmooo/0.jpg)](https://www.youtube.com/watch?v=4N8u5OHmooo)

## How to Use

1. The AudioAnalyzer script doesn't need anything setup. It only needs to be attached to the music component or any other audio source within the scene. All LightingEqualizer scripts will access this one scripts to equalize to.

2. Attach the LightingEqualizer script to any component you want to be effected by the music/sound effects of your scene.

3. Ensure the object you attached the script to has either a light component or material set. The equalizer will grab the light and/or material component automatically if it exists. If you don't want the material to be effected, just leave the colorShaderName field blank.

4. Mess with the intensity while the scene is running to get the desired effect.
