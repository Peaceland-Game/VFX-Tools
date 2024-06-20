/*
Adapted from Unity 2D Simple Noise:
https://docs.unity3d.com/Packages/com.unity.shadergraph@7.1/manual/Simple-Noise-Node.html

William Duprey
6/19/24
Simple Noise 3D
INCOMPLETE
*/

inline float randomValue(float3 uv)
{
	return frac(sin(dot(uv, float3(12.9898, 78.233, 51.582))) * 43758.5453);
}

inline float interpolate(float a, float b, float t)
{
	return (1.0 - t) * a + (t * b);
}

inline float valueNoise(float3 uv)
{
	float3 i = floor(uv);
	float3 f = frac(uv);
	f = f * f * (3.0 - 2.0 * f);

	uv = abs(frac(uv) - 0.5);
	float3 c0 = i + float3(0.0, 0.0, 0.0);
	float3 c1 = i + float3(1.0, 0.0, 0.0);
	float3 c2 = i + float3(0.0, 1.0, 0.0);
	float3 c3 = i + float3(0.0, 0.0, 1.0);
	float3 c4 = i + float3(1.0, 1.0, 0.0);
	float3 c5 = i + float3(1.0, 0.0, 1.0);
	float3 c6 = i + float3(0.0, 1.0, 1.0);
	float3 c7 = i + float3(1.0, 1.0, 1.0);
	float r0 = randomValue(c0);
	float r1 = randomValue(c1);
	float r2 = randomValue(c2);
	float r3 = randomValue(c3);
	float r4 = randomValue(c4);
	float r5 = randomValue(c5);
	float r6 = randomValue(c6);
	float r7 = randomValue(c7);
	
	float bottomOfGrid = interpolate(r0, r1, f.x);
	float topOfGrid = interpolate(r2, r3, f.x);
	float t = interpolate(bottomOfGrid, topOfGrid, f.y);
	return t;
}

void SimpleNoise3D_float(float3 UV, float Scale, out float Out)
{
	float t = 0.0;

	float freq = pow(2.0, float(0));
	float amp = pow(0.5, float(3 - 0));
	t += valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

	freq = pow(2.0, float(1));
	amp = pow(0.5, float(3 - 1));
	t += valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

	freq = pow(2.0, float(2));
	amp = pow(0.5, float(3 - 2));
	t += valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

	Out = t;
}