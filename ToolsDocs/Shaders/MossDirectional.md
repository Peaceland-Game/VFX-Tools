![[MossDir.png]]

A tool used to blend a texture onto another surface. This is a quick method to add moss to objects that don't have it already painted on it by using a direction a voronoi noise.

## Variables
| Name               | Type      | Use                                                    |
| ------------------ | --------- | ------------------------------------------------------ |
| BaseTexture        | Texture2D | Albedo of what is underneath the moss                  |
| Metallic           | Texture2D | Metallic of what is underneath the moss                |
| Smoothness         | Texture2D | Smoothness of what is underneath the moss              |
| UVTile             | Vector2   | UV tiling of entire uvs of object                      |
| UVOffset           | Vector2   | UV offset of entire uvs of object                      |
| Dir                | Vector3   | Direction moss should grow from                        |
| VoronoiOffset      | float     | Voronoi noise used to smooth transition's cell offset  |
| VoronoiCellDensity | float     | Voronoi noise used to smooth transition's cell density |
| MossSmoothstep     | Vector2   | Blend smoothstep                                       |
| MossAO             | Texture2D | Moss ambient occulusion                                |
| MossColor          | Texture2D | Moss Albedo                                            |
| MossNormal         | Texture2D | Moss Normal                                            |
| MossRoughness      | Texture2D | Moss Roughness                                         |
