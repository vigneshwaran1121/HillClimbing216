# HillClimbing216
Hill Climbing Clone ( Unity )

A 2D physics-based hill climbing mobile game built using Unity.

Gameplay

- Touch **left side** of the screen → Reverse
- Touch **right side** of the screen → Forward
- Drive across infinite procedural hills
- Collect fuel to survive
- Game ends when:
  - Fuel reaches 0
  - Driver hits the ground

Distance travelled is tracked in real time.

---

Core Systems

Car Controller
- Rigidbody2D wheel torque system
- Air rotation control
- Ground detection system

Procedural Terrain
- Generated using Perlin Noise
- Seamless chunk-based terrain streaming
- Infinite world system

 Fuel System
- Gradual fuel drain
- Fuel pickup refill system
- Dynamic UI fill + color gradient

Game Manager
- Handles Game Over state
- Restart system
- Time scale control

---

Project Structure

Scripts Included

- `CarDrive.cs` → Handles car movement, wheel torque, and air rotation  
- `CollectFuel.cs` → Detects fuel pickup collisions and refills fuel  
- `DisplayDistanceText.cs` → Tracks and displays distance travelled  
- `FuelController.cs` → Manages fuel drain, refill, and UI updates  
- `GameManager.cs` → Controls game state, restart, and game over logic  
- `OrientationFix.cs` → Forces correct landscape orientation on mobile  
- `ScreenManager.cs` → Handles screen setup and resolution behavior  
- `TerrainChunk.cs` → Generates procedural terrain using Perlin Noise  
- `TerrainChunkSpawner.cs` → Spawns and manages infinite terrain chunks  


---

Controls

Mobile
- Left Screen → Reverse
- Right Screen → Forward

Editor Testing
- Left Arrow → Reverse
- Right Arrow → Forward
- Mouse Click (left/right half of screen)

---

Built With

- Unity (Latest LTS)
- C#
- Unity 2D Physics
- SpriteShape
- Cinemachine

---

How to Run

1. Clone the repository  
2. Open in Unity (Latest LTS recommended)  
3. Open the main scene  
4. Press Play  

For Android build:
- Switch platform to Android  
- Set Orientation to Landscape  
- Build & Run  

Google Drive Link for APK

https://drive.google.com/drive/folders/1BQEHBtcPTlihtPXHSYj1t65oqgwacvP7?usp=drive_link
---

Future Improvements

- Engine sound & audio effects
- Obstacles & collectibles
- Difficulty scaling
- Biome variation system
- Improved mobile UI buttons
- Menubar, Settings

---

By

Created by ( Vigneshwaran )
