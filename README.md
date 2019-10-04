# Dijkstra Visualization

![Game screenshot](https://imgur.com/1frrasU.png)
## About
![Dijkstra Animation](https://upload.wikimedia.org/wikipedia/commons/5/57/Dijkstra_Animation.gif)
[GameOn Production](https://www.gameonproduction.com/) test task source code

Dijkstra's Shortest Path First algorithm implementation

This project is an implementation of the [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm) and also my dive into developing tools under Unity Editor API


## Installation
1. [Download](https://github.com/cornflux-cmd/dijkstra-visualization/releases/latest) the latest version of the package
2. Import the package into your project
3. See [Usage](#usage)

## Usage
### Editor
1. Create your own **Graph** by dragging its prefab onto the scene or use *Demo* scene
2. Drag **Vertices** prefab onto the **Graph** in Hierarchy, making them its children
3. Connect the **Vertices'** by specifying connections in each **Vertex's** corresponding component  
**Note:** you only need to connect **Vertices** ONCE, algorithm will sync all pairs
4. Under **Shortest Path** component on the **Graph** specify *Start* and *Finish* vertices
5. Click *Build* under **Graph's** component
6. **Path** will be highlighted with Green color, starting *Edge* will be marked Red

### Runtime
Not yet fully supported, try at your own risk

*Drawn inspiration for visuals from [this](https://github.com/EmpireWorld/unity-dijkstras-pathfinding)*
___
<p align="center">
  <b>Made With</b><br>
  <a href="https://unity.com/"><img src="https://unity3d.com/files/images/ogimg.jpg"</a>
</p>
