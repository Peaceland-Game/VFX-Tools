using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGenerator : MonoBehaviour
{
    [SerializeField] float length;
    [SerializeField] int iterations;

    [Tooltip("Spread value used to create catenary. Generated using calculate button")]
    [SerializeField] float spread;

    /// <summary>
    /// How many steps the algorithm will search for the first overeach when 
    /// looking for the out bounds of a. Farthest value equal to 2^MAX_STEPS
    /// </summary>
    private const int MAX_STEPS = 32; 

    /// <summary>
    /// Generates the "a" variable used for the catenary equation 
    /// </summary>
    public void Calculate()
    {
        // Check if in range 
        //  s > |p1 - p0|

        // Check which direction to search in 


        for (int i = 0; i < MAX_STEPS; i++)
        {
            // Search for first overeach 
        }

        // Target is too far 
    }

    /// <summary>
    /// Using the 
    /// </summary>
    public void GenerateWire()
    {

    }



    /// <summary>
    /// Forms a catenary referencing this page: 
    /// https://foggyhazel.wordpress.com/2018/02/12/catenary-passing-through-2-points/
    /// </summary>
    /// <param name="a">Spread value</param>
    /// <param name="x0"></param>
    /// <param name="y0"></param>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    private float Catenary(float a, float x0, float y0, float x1, float y1, float x)
    {
        float d0 = 0.5f * (Mathf.Abs(x1 - x0));
        float numA = x - (x0 + d0);
        float k = x0 + d0;

        return (a * Cosh(numA / a)) + (y0 - a * Cosh((x - k) / a)) - y1;
    }

    /// <summary>
    /// Hyperbolic cosine 
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private float Cosh(float t)
    {
        return (Mathf.Pow(Mathf.Epsilon, t) + Mathf.Pow(Mathf.Epsilon, -t)) / 2.0f;
    }
}
