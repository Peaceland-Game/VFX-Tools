Mostly copied from here: 
https://github.com/JimmyCushnie/Noisy-Nodes/tree/master 
Additional insight from here:
https://thebookofshaders.com/12/


![[Media/Voronoi3DDemo.mp4]]
Works just like the built-in Unity Voronoi 2D noise, but in 3D. Useful for if noise textures are needed on 3D objects, like cylinders or spheres, avoiding unsightly seams.
## Variables
| Name                | Type    | Use                                                       |
| ------------------- | ------- | --------------------------------------------------------- |
| SamplingCoordinates | Vector3 | The input coordinates for the noise.                      |
| AngleOffset         | Float   | How offset the cells will be. 0 produces a straight grid. |
| CellDensity         | Float   | The scale and size of cells, how many there will be.      |



