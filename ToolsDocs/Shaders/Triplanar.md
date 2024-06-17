![[Triplanar.png]]

Instead of using UVs created by an artist specifically for a model these create UVs based on position and blend based on normals. Uses the [[TriplaneTextures]] subnode. 

## Variables
| Name         | Type      | Use                            |
| ------------ | --------- | ------------------------------ |
| FrontTexture | Texture2D | Albedo of face front and back  |
| FrontTiling  | Vector2   | Front UV Tiling                |
| FrontOffset  | Vector2   | Front UV Offset                |
| SideTexture  | Texture2D | Albedo of face on sides        |
| SideTiling   | Vector2   | Side UV Tiling                 |
| SideOffset   | Vector2   | Side UV Offset                 |
| TopTexture   | Texture2D | Albedo of face above and below |
| TopTIling    | Vector2   | Top UV Tiling                  |
| TopOffset    | Vector2   | Top UV Offset                  |
| Sharpness    | Float     | Affects blending between faces |


