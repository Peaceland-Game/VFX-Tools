![[Gem.png]]

A test shader that is uses a  parallax occulusion mapping node in order to create a fake level of depth. This material in particular uses caustic texture. 

## Variables
| Name              | Type      | Use                                                                   |
| ----------------- | --------- | --------------------------------------------------------------------- |
| GemPattern        | Texture2D | Texture sampled for parallax occulusion mapping                       |
| Tiling            | Vector2   | GemPattern uv tiling scale                                            |
| Offset            | Vector2   | GemPattern texture uv offset                                          |
| ParallaxAmplitude | Float     | Depth caused by parallax                                              |
| Steps             | Float     | Levels of resolution for parallax                                     |
| EmissionColor     | Color     | Emissive color of gem. Works using the texture outputted the parallax |
| MainColor         | Color     | Total color of the mesh. Does not account for the parallax            |


