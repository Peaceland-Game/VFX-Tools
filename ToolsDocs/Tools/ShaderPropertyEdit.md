![[ToolsShaderPropertyEdit.mp4]]

Allows for the quick randomization of parameters of the shader given to it which can then be applied to given materials. In the example above we have the tool load the [[GoopyGem]] shader and we have defined random ranges for it to generate from. 

When reading from the the shader it will convert parameters into ranges. The following transformation are as follows.

| Original | Conversion   |
| -------- | ------------ |
| Color    | Gradient     |
| Vector   | Two Vector4s |
| Float    | Vector2      |
| Range    | Vector2      |
| Texture  | Texture      |
| Int      | IntVector2   |

## Variables 

| Name                 | Type                    | Use                                                                                               |
| -------------------- | ----------------------- | ------------------------------------------------------------------------------------------------- |
| Shader               | Shader                  | What will be reference to build the properties                                                    |
| Target Materials     | List\<Material>         | Materials that the generated properties                                                           |
| Properties Ranges    | RangeProperties         | What the tool will randomly pick between for each parameter generated from the shader             |
| Num To Generate      | Int                     | How many different property sets would like to generate.                                          |
| Generated Properties | List\<ShaderProperties> | The generated properties which are equivalent to a material generated by the shader's parameters  |

## Buttons
| Name                       | Use |
| -------------------------- | --- |
| Load Properties Blueprint  |     |
| Override Properties Ranges |     |
| Generate Random Properties |     |
| Load into Target Materials |     |