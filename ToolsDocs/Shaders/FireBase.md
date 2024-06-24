![[FireVFX.png]]

Generates a fire like shader that uses gradient noise and shapes it based on the curve of a parabola. This is the primary material used for the [[Styled Fire]] vfx. Internally it has a gradient that it samples from which cannot be exposed. 
## Variables
| Name          | Type    | Use                                                  |
| ------------- | ------- | ---------------------------------------------------- |
| AnimSpeed     | Float   | How fast should the noise scroll                     |
| NoiseScale    | Float   | Scaling of noise which affects density and sharpness |
| EmissionScale | Float   | Strength of emission                                 |
| RandomID      | Float   | Used for randomized noise pattern                    |
| parabA        | Float   | Represents *a* within the standard parabola form     |
| parabB        | Float   | Represents *a* within the standard parabola form     |
| parabOffset   | Vector2 | Offsets the parabola                                 |
| parabScale    | Float   | Scales the parabola                                  |

