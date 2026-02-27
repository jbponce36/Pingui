# Pingui by jbponce36

![Penguin Banner 2](https://github.com/jbponce36/Pingui/assets/12723528/3d45cdc1-bc61-4583-a313-39a10d24c5db)

Pingui is an endless runner (jumper?) platform game where you control Pingui and help him climb the mountain. Evade enemies and collect keys to unlock chests along the way.

<hr>

<img src="https://img.itch.zone/aW1hZ2UvMjE4ODc3NS8xMjk0NTc2Ny5wbmc=/347x500/V1h%2F42.png" width="33.3%"><img src="https://img.itch.zone/aW1hZ2UvMjE4ODc3NS8xMjk0NTc2OC5wbmc=/347x500/8LZUsi.png" width="33.3%"><img src="https://img.itch.zone/aW1hZ2UvMjE4ODc3NS8xMzAxNDY2MS5wbmc=/347x500/YrRMjR.png" width="33.3%">

## Getting started
- Try it on itch.io: https://jbponce.itch.io/pingui


## Controls
- Arrow keys or WASD keys: Move the player.

## Specifications 

### Game Engine
Unity

### GameStates
#### StartState
Spawns starting falling tiles and waits for player to start the game. Shows the exit button on PC and Android.
#### PlayState
The main level of the game where the player can jump on the tiles to collect keys to open chests and evade enemies and obstacles.
#### RetryState
Darkens the screen and shows the retry button.

## Technical features
- Camera moves faster if the player is near the top of the screen.
- Use of interfaces for state handling.
- Rows of tiles get created when the camera reaches the top of the screen.
- Custom gravity so the player falls faster
- Movement is separated in 2 axis: Instead of using a diagonal force vector for the jump impulse, it's separated in its Y and Z components. Player jumps vertically using Y jump impulse component and moves forward or backwards linearly using Z component. When the player collides with the ground, stop all movement and correct the position.
- To check if the player can move to a certain position, overlap a sphere at the position where the player wants to move and check for collisions with obstacles.
- Jump sound pitch changes slightly and randomly everytime the player jumps for variety.
- Trees opacity turns down when the player is behind them. For this, [Alex Ocias' dither transparency shader](https://ocias.com/blog/unity-stipple-transparency-shader/) was used. Simply making the material transparent wouldn't work because trees will render incorrectly.

<b>Dither transparency preview</b>

<img src="https://img.itch.zone/aW1hZ2UvMjE4ODc3NS8xMjk0NTc2OS5wbmc=/347x500/m%2FXQVf.png">

## Assets

### Models
Models for the player, tiles, obstacles and enemies where taken from these assets packs from the Unity Assets Store:

Title: Voxel Environments 1  
Author: SURIYUN  
URL: https://assetstore.unity.com/packages/3d/environments/fantasy/voxel-environments-1-152920  

Title: 5 animated Voxel animals  
Author: VoxelGuy  
URL: https://assetstore.unity.com/packages/3d/characters/animals/5-animated-voxel-animals-145754  

Title: Free Low Polygon_Animal  
Author: GLOOMY STUDIO  
URL: https://assetstore.unity.com/packages/3d/characters/animals/free-low-polygon-animal-110679  

### UI
Title: Game Icons  
Author: Kenney  
URL: https://opengameart.org/content/game-icons   
Copyright/Attribution Notice: "www.kenney.nl"  

### Shader
Title: Unity Stipple Transparency Shader  
Author: Alex Ocias  
URL: https://ocias.com/blog/unity-stipple-transparency-shader/  

### Fonts
Title: Dark Forest  
Author: dcoxy  
URL: https://www.1001freefonts.com/dark-forest.font

### Sounds and Music
Title: Interface Sounds  
Author: Kenney  
URL: https://opengameart.org/content/interface-sounds  
Copyright/Attribution Notice: "www.kenney.nl"  

Title: Cutie Pie  
Author: FrancisLeeMusic  
URL: https://opengameart.org/content/cutie-pie  
File(s): cutie_pie.wav (converted to mp3 and cut)  

## Credits
Made by: Julieta Belén Ponce

<img src="https://github.com/jbponce36/Pingui/assets/12723528/2ec7fe0f-4bf6-4a09-8bd6-9a6bded9b149" width="200">

