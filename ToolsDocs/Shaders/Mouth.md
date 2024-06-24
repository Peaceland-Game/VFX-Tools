This shader controls the mouth(s) on characters, and allows for varied mouth shapes (currently only ovals), positions, wobbly movement, and changes in size to simulate talking.

## Variables
| Name               | Type    | Use                                                                                                                                                                                        |
| ------------------ | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| MouthColor         | Color   | The color of the inner mouth oval. Can be affected by emission, assuming EmissionMulitiplier is not set to 0.                                                                              |
| MouthBaseSize      | Vector2 | The starting size of the mouth, which is scaled up or down depending on the TalkXRange and TalkYRange values.                                                                              |
| SilentMouthSize    | Vector2 | The size the mouth is set to when not talking (scaling up and down).                                                                                                                       |
| OutlineColor       | Color   | The color of the mouth outline, unaffected by emission.                                                                                                                                    |
| OutlineThickness   | Vector2 | The thickness of the outline around the mouth. Typically, the X and Y should be set to the same value, usually around 0.03. The Y component could be increased to simulate thicker lips.   |
| EmissionMultiplier | Float   | How much to scale the emission on the inner mouth.                                                                                                                                         |
| MouthCenter        | Vector3 | The center of the mouth, offset from the center of the Quad displaying it.                                                                                                                 |
| WobbleDistance     | Float   | How far the mouth will wobble. Can be set to 0 to disable wobbling. In most cases, it's best to leave it off, as having wobbling and size-changing at the same time can look disorienting. |
| WobbleScale        | Vector2 | How much the X and Y gradient noise is scaled when generating the wobble center (higher values lead to a greater wobble).                                                                  |
| WobbleSpeed        | Float   | How quickly the mouth wobbles (if at all).                                                                                                                                                 |
| TalkSpeed          | Float   | How quickly the mouth sizes up and down when talking.                                                                                                                                      |
| TalkScale          | Vector2 | How much the X and Y gradient noise is scaled when randomly sizing up and down.                                                                                                            |
| TalkXRange         | Vector2 | The upper and lower ranges for scaling the mouth in the X direction.                                                                                                                       |
| TalkYRange         | Vector2 | The upper and lower ranges for scaling the mouth in the Y direction.                                                                                                                       |

