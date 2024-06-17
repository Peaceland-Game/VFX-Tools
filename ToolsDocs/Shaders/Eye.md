This shader controls eyes on characters, and allows for varied eye shapes, positions, and wobbly movement. 

Incomplete, punch this up a bit later:
To properly make use of this shader, first have quads for each eye parented to a character GameObject, then add the [[CharacterVisualController]] script to that parent GameObject. In the inspector, add each eye quad's mesh renderer to the "Eyes" list. To actually be able to edit the properties of the shader, however, the CharacterVisualController will need a "blueprint" of the shader's properties.

First click the "Load Properties Blueprint" button, then click the "Override Properties Ranges" button. The "Properties Ranges" dropdown should now contain every property of the shader graph as an editable field. Right click on "Properties Ranges" and select "Copy." Then, navigate back to the CharacterVisualController object, and paste into the "Eye Settings."
## Variables
| Name               | Type    | Use                                                                                                                                                                                                                                                    |
| ------------------ | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| EyeCenter          | Vector3 | The position of the eyes, in relation to their local position. <br>Note: if the eye has a cutout portion, the cutout will not move along with the eye center and will need to be manually positioned as well.                                          |
| EyeSize            | Vector2 | The X and Y scale of the eye. <br>Values between 0.05 and 0.1 produce the best results.<br>Note: OutlineSize will need to be manually adjusted to fit the new eye size.                                                                                |
| EyeColor           | Color   | The color of the eyes.<br>Note: the eyes also have emission, so depending on the EmissionMultiplier, the eyes may appear a brighter color than specified.<br>Also note: setting the eyes black will make the entire eye the same color as the outline. |
| OutlineSize        | Vector2 | The X and Y scale of the eye outline. Setting this value lower than the EyeSize can result in oddities, so for best results, its components should always be greater than those of EyeSize.                                                            |
| OutlineColor       | Color   | The color of the outline.                                                                                                                                                                                                                              |
| Smoothness         | Float   | The metallic smoothness of the eyes. Setting it above 0 will result in the eyes reflecting light.                                                                                                                                                      |
| EmissionMultiplier | Float   | How brightly the eyes will emit their own light. Uses the eye base color.                                                                                                                                                                              |
| WobbleSpeed        | Float   | How quickly the eyes will wobble. At 0, the eyes will not wobble at all.                                                                                                                                                                               |
| WobbleDistance     | Float   | How far from their starting positions the eyes will wobble. Anything higher than 0.2 will result in the eyes wobbling far off of the face.                                                                                                             |
| WobbleScale        | Vector2 | How much the eyes will wobble in the X and Y directions. The lower the value, the more the eyes will wobble in that direction.                                                                                                                         |
| CutoutCenter       | Vector3 | The center of the circular cutout, in relation to the eye's center position.                                                                                                                                                                           |
| CutoutCenterOffset | Vector3 | Used internally to handle left and right eye cutouts being mirrored. Its value is overridden when applied to the material, so it should be ignored.                                                                                                    |
| CutoutRange        | Float   | How large the circular cutout is.                                                                                                                                                                                                                      |