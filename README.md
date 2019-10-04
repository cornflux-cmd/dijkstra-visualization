# Dijkstra Visualization

![Game screenshot](https://imgur.com/U2VmTOB.png)
## WIP
[GameOn Production](https://www.gameonproduction.com/) test task source code

Dijkstra's Shortest Path First algorithm implementation

This project is an implementation of the [Dijkstra's algorithm](https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm) and also my dive into developing tools under Unity Editor API
![Dijkstra Animation](https://upload.wikimedia.org/wikipedia/commons/5/57/Dijkstra_Animation.gif)

## Installation
1. [Download](https://github.com/cornflux-cmd/dijkstra-visualization/releases/latest) the latest version of the package
2. Import the package into your project
3. See [Usage](#usage)

## Usage
### Editor
1. Create your own **Graph** by dragging its prefab onto the scene or use *Demo* scene
2. Drag **Vertices** onto the **Graph** in Hierarchy, making them its children
3. Connect the **Vertices** by specifying connections in each **Vertex's** corresponding component  
**Note:** you only need to connect **Vertices** ONCE, algorithm will sync all pairs
4. Click on **Graph** and press *Build*

### Runtime
Not yet fully supported, try at your own risk
