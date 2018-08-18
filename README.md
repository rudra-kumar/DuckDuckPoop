# Duck Duck Poop

This is a **networked multiplayer** game for iOS and Android developed at a gamejam within 48 hours, the game was developed in Unity3D and overrides their multiplayer network API.

This by no means represents good coding standards and is basically throwaway code, but good enough to give you an idea of overriding Unities API and instantiating multiple prefabs over the network. 

The reason why this was a challenge is because nowhere on the internet you can find a resource where you can instantiate two completely different characters over the network using Unities Networking API's and is very poorly documented. 


## About the game
This is a multiplayer game where one player is the duck and the other player hunts the duck. The hunter can shoot the duck but here is the twist - The bullets don't disappear after being fired but instead, start going around the tiny planet. So if the hunter is not careful the bullet could go around the planet and kill the hunter. The duck, on the other hand, can duck and poop and the bullet ricochets off the poop. Whoever dies first loses the game. The game is cross-platform, runs on iOS / Android over the network and also has split-screen.
