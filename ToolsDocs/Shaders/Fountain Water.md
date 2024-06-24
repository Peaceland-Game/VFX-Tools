![[FountainWaterDemo.mp4]]

This shader simulates water streaming down a fountain. It uses the [[Voronoi 3D Noise]] subgraph to achieve this effect, by stretching out the Y component and moving downward. The centers of the cells are made transparent to simulate the water breaking apart as it falls.
## Variables
| Name            | Type    | Use                                                                                                                                                       |
| --------------- | ------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RippleSpeed     | Vector3 | The speed and direction of the water ripples. For this shader, the default is a downwards speed of 5.                                                     |
| StretchY        | Float   | How much to stretch the Y component for the Voronoi3D input coordinates (uses a lerp from 0 to the value, so smaller values equate to longer stretching). |
| VoronoiAngle    | Float   | The AngleOffset value for the Voronoi3D node. At 0, produces an even grid of cells.                                                                       |
| VoronoiDensity  | Float   | The CellDensity value for the Voronoi3D node. Higher values produce more, and more tightly packed cells.                                                  |
| RippleIntensity | Float   | How much the Voronoi cells are darkened.                                                                                                                  |
| BottomStrength  | Float   | How much the bottom UVs are brightened, producing a gradient effect.                                                                                      |
| WaterColor      | Color   | The color of the water. Very self-explanatory.                                                                                                            |
| AlphaScale      | Float   | How much the dark centers of the cells will be made transparent. 0 results in everything being made transparent.                                          |

