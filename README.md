# Integrated Project Sem2.1
 Jaslyn, Kirdesh and Dan
 
 Key Controls

Player Navigation : W,A,S,D or the Up,Down,Left,Right keys
Jump : Spacebar
Dash : Left Shift
Quest Panel (Left Side) : Q to open, E to close
Menu Panel (Right Side) : O to open, P to close


Answer Key

The following quest can be completed by
Quest 1 - Defeat 5 enemies, there will be 5 enemies at the castle level, defeating them will complete the quest
Quest 2 - Get to the shelve, the shelves are at the back corner of the store, near the castle level, players are required to jump on the hamburger trampoline to gain access to the next level
Quest 3 - Completing the maze, the maze can be entered once you reach the shelves, once you reach the exit of the maze, the quest will be completed
Quest 4 - Defeat the train conductor, there will be enemies near the moving toy train and on the train itself, defeating the enemies should complete the quest
Quest 5 - Defeat the penguin boss, the penguin boss can be found on the final level, as the boss has a large amount of health, shooting him will cause him to spawn little penguin minions to fight you. Defeating the penguin boss will trigger the completion of the final quest


Platforms/hardware/desired settings

Windows x86_64


Limitations or bugs in the application

When player tries to press the back button, character does not move correspondingly


Scripts Used :
Kirdesh
EnemyFollow - Main Ai for the melee enemies that chase the player
EnemyHealth - Syncs the enemy health to be dispayed in the UI healthbar
HideMouse - Hide and Locks the mouse when game starts
SimpleEnemyHealth - Contains info of the enemy health, and events that are triggered based on the health
playerEvents (main player events for the collision with objects to trigger certain events)
Walking controls (events for the collision with objects)

Jaslyn
UI Animationa - Animations for the UI menu (in-game) 
Boss Script - AI for the Boss and the spawning of the minions, attack takes time to reset
Main menu - script that handles all buttons for main menu
playerEvents (Quest debug logging and cancelling quest that have already been completed)
Walkingcontrol - Audio for movements & the changing of directions following mouse inputs

Dan
Block Clash - Collision of the block to trigger audio
HealthBar - Healthbar for the player that tracks the health of the player
Rangedenemy - Ai for the ranged enemy that throws objects at the player, maintain a distance from the player, attack takes time to reset
Shooting - raycast and damaging enemies
playerEvents (Kill counter and changing of scenes when certain conditions are met)
Walkingcontrol - Main character movements


References

All models and textures used are designed by us
Scripts have been written and modified by us
Audio Sources :
Most sound effects are from : https://freesound.org/
Cinemation for camera from Unity itself

Components were referenced from YouTube, Unity Answers and Stack Overflow. mentions to Brackeys from YouTube : https://www.youtube.com/user/Brackeys
