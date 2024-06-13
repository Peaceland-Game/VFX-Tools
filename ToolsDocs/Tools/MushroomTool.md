![[ToolsMushroom.mp4]]

This tool is used to quick add mushrooms along the given gizmos path. Their are spawned locally to the tool's transform which means however the tool is oriented they spawn with it. 

## Variables
| Name              | Type     | Use                                                                                                                                                                              |
| ----------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Spawn Length      | Float    | The length of the line segment that mushrooms are spawned on                                                                                                                     |
| Lean Dir A        | Vector 2 | One of the edge directions used to determine where the mushroom leans toward. Influences the green arrow which represents the middle of the range that mushroom can lean towards |
| Lean Dir B        | Vector 2 | One of the edge directions used to determine where the mushroom leans toward. Influences the green arrow which represents the middle of the range that mushroom can lean towards |
| Reverse Lean Dir  | Bool     | Inverses the range of directions that the mushrooms can lean towards                                                                                                             |
| Tilt Strength Min | Float    | What is the minimum interpolation that mushroom can lean. 0 aligns vertically with the tool's up vector and 1 aligns with the random vector along the lean dir plane             |
| Tilt Strength Max | Float    | What is the maximum interpolation that mushroom can lean. 0 aligns vertically with the tool's up vector and 1 aligns with the random vector along the lean dir plane             |
| Spawn Count       | Int      | How many mushrooms would you like to spawn along the spawn length                                                                                                                |

## Buttons 
| Name                       | Use                                                                                       |
| -------------------------- | ----------------------------------------------------------------------------------------- |
| Redistribute Mushrooms     | Positions the mushrooms randomly along the spawn length                                   |
| Randomize Attributes       | Randomizes the orientation of the mushrooms based on the constraints set by the variables |
| Spawn Random Mushroom Type | Swaps out the meshes of the mushrooms for a random one selected by the mushroom pool      |
| Clear                      | Removes all mushroom objects and cleans them from the scene                               |
