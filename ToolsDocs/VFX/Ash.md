![[VFXAshDemo.mp4]]

This VFX creates emissive particles that transition through a color gradient over their lifetime. The particles scale based on their speeds, creating a trail-like effect. The particles undergo turbulence as they travel, wavering in random directions. The spawn point of the particles wobbles back and forth over time using a sine wave. In hindsight, maybe this particle system should have been called "Ember," since ashes are usually duller. 

The intended use for this particle system was during the riot sequence. The position could be set above the camera, so that ashes periodically appear around the player, to simulate the city being aflame.
## Variables
| Name             | Type           | Use                                                                                                                                                                                                              |
| ---------------- | -------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| SpawnRate        | Float          | The period of time for each burst of particle spawning. The lower the number, the faster new bursts of particles will spawn.                                                                                     |
| SpawnRange       | Vector2        | The lower and upper range for particle spawning time. The closer the two numbers, the more consistently particles will spawn. A greater range results in more discrete bursts of particles.                      |
| Lifetime         | Vector2        | The lower and upper bounds for the randomly chosen lifetime for the particle.                                                                                                                                    |
| StartVelocityMin | Vector3        | The lower bound for each particle's randomly chosen starting velocity.                                                                                                                                           |
| StartVelocityMax | Vector3        | The upper bound for each particle's randomly chosen starting velocity.                                                                                                                                           |
| BaseColor        | Color          | The color of the ash particles (with no emission applied).                                                                                                                                                       |
| EmissionColors   | Color Gradient | The emissive gradient that each particle goes through during its lifespan. By default, it starts out yellow, then transitions to red, then instantly transitions to full transparency, resulting in no emission. |
