## About
Astrolight is an independent paranormal game developed by Team Ajaqxz in 48 hours as a submission to the 2020 Global Game Jam competition. The competition's theme was "Repair" and this game implemented the theme through accomplishing objectives necessary to achieve victory conditions.

The game features the "Player" as being stuck in a disabled starship following a loss of power. The "Player" must reach and interact with three generator entities to restore ships power, upon which the victory conditions are satisifed. In opposition to the "Player" are two alien entities. Both alien entities, upon physical contact with the "Player" results in an immediate loss.

## Enemy Entities

The "Hunter" is an entity with a constant awareness of the position of the "Player." The "Hunter" is constantly moving towards the position of the "Player" at a very low speed.

The "Chaser" is a conditional entity with a constant awareness of the position of the "Player." The "Chaser" is active when at least one generator has been activated.  The "Chaser" is constantly moving towards the position of the "Player at a high speed. Upon contact with the light of the "Player" the "Chaser" teleports away.


## Scripts

### PlayerController.cs

Controls the movement and camera orientation of the "Player."

### GameMaster.cs

Keeps track of important game entities. Waits for any death instances, and cleans up upon a win.

### Generator.cs

Keeps track of generator repair status, and tracks collisions with the "Player".

### PauseMenu.cs

Sets timescale to zero, and provides access to the canvas with several options.

### DeathMenu.cs

Loads the canvas within the Death Menu

### ChaserController.cs

Controls the enemy entity "Chaser." "Chaser" is activated when the number of generators repaired is greater than zero. Upon entering within trigger spheres oriented by the spotlight's position, the "Chaser" has its rendering and colliders disabled and is teleported to a separate location. After approximately 30 seconds, the Chaser will respawn.

### MonsterController.cs

Controls the enemy entity "Hunter." "Hunter" is activated immediately and will move towards the "Player" at a slow speed.

### WallHider.cs

Disables walls that interfere with the camera's view of the "Player."
