
![[ShaderGoopyGem.mp4]]

The primary shader used to help visualize the characters for the game. This shader is a blend between two different noises types that allows us to smoothly interpolate between. Both the voronoi and simple noise variations start with generating an oval using a signed distance field before offsetting the positions of the circle by the noise value. 

## Variables
| Name                      | Type             | Use                                                                                       |
| ------------------------- | ---------------- | ----------------------------------------------------------------------------------------- |
| Times                     | Vec2             | The timescale on each axis. Acts as both timescale and direction of pattern               |
| NoiseType                 | Float Range(0,1) | Interpolate range between voronoi and simple noise                                        |
| Rescale                   | Float            | Extra scaling of noises                                                                   |
| SimpleNoiseScale          | Float            | Scaling and simple noise density and sharpness                                            |
| SimpleGradientThresholdA  | Float            | Min value used to change between secondary and highlight                                  |
| SimpleGradientThresholdB  | Float            | Max value used to change between highlight and primary                                    |
| SimpleCenter              | Vector2          | Offsets the center of the simple noise                                                    |
| SimpleSize                | Vector2          | Scale that shows how much noise should be displayed of the surface                        |
| AngleOffset               | Float            | Separation of the voronoi noise cells                                                     |
| CellDensity               | float            | Density of the voronoi noise cells                                                        |
| VoronoiGradientThresholdA | Float            | Min value used to change between secondary and highlight                                  |
| VoronoiGraidentThresholdB | Float            | Max value used to change between highlight and primary                                    |
| VoronoiCenter             | Vector2          | Offsets the center of the voronoi noise                                                   |
| VoronoiSize               | Vector2          | Scale that shows how much noise should be displayed of the surface                        |
| Primary                   | Color            | Outer level of color and default color                                                    |
| Secondary                 | Color            | Inner filled color                                                                        |
| Highlight                 | Color            | The barrier color between the primary and secondary colors. Acts like an internal outline |
| Saturation                | Float            | Turns colors into greyscale at 0                                                          |
| PrimaryMetallic           | Float            | Metallic of primary color area                                                            |
| SecondaryMetallic         | Float            | Metallic of secondary color area                                                          |
| PrimarySmoothness         | Float            | Smoothness of primary color area                                                          |
| SecondarySmoothness       | Float            | Smoothnessof secondary color area                                                         |
| DisplacementScale         | Float            | Affects how far vertices are offset from noise                                            |
| VertexAngleOffset         | Float            | Voronoi noise used to offset vertices' cell angle offset                                  |
| VertexCellDensity         | Float            | Voronoi noise used to offset vertices' cell density'                                      |
| DisTimeScale              | Float            | Animation time scale of vertex wobble                                                     |

