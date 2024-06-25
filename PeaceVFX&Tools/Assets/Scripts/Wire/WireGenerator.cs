using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WireGenerator : MonoBehaviour
{
    [SerializeField] float length;
    [SerializeField] int iterations;

    [SerializeField] Points points;

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

        Vector3 lowerPoint, upperPoint;
        if(points.PointA.y < points.PointB.y)
        {
            lowerPoint = points.PointA;
            upperPoint = points.PointB;
        }
        else
        {
            upperPoint = points.PointA;
            lowerPoint = points.PointB;
        }
        
        // Create vector which lets us find x value local to it 
        Vector3 catenaryAxis = Vector3.ProjectOnPlane(lowerPoint - upperPoint, Vector3.up).normalized;
        float x0 = Vector3.Dot(lowerPoint, catenaryAxis); // Fix to be correct dir 
        float x1 = Vector3.Dot(upperPoint, catenaryAxis);
        
        for (int i = 0; i < MAX_STEPS; i++)
        {
            // Search for first overeach 

            // Difference between y created by catenary both at x1
            float difference = Catenary(Mathf.Pow(2, i), x0, lowerPoint.y, x1, upperPoint.y, x1, length) - upperPoint.y;
            
            // Is catenary overextended yet? 
            if(difference < 0.0f)
            {
                // Begin iterations search 
                spread = HalfSearch(i > 0 ? Mathf.Pow(2, i - 1) : 0.00001f, Mathf.Pow(2, i), x0, lowerPoint.y, x1, upperPoint.y, length);
                return;
            }
        }

        // Target is too far 
        Debug.LogWarning("Points are too far from one another. Max distance is 2^" + MAX_STEPS.ToString());
    }

    /// <summary>
    /// Closes in on an ideal spread value using a half search algorithm 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="x0"></param>
    /// <param name="y0"></param>
    /// <param name="x1"></param>
    /// <param name="y1"></param>
    /// <returns></returns>
    private float HalfSearch(float min, float max, float x0, float y0, float x1, float y1, float s)
    {
        float value = 0.0f;

        for (int i = 0; i < iterations; i++)
        {
            value = (max + min) / 2.0f;
            float difference = Catenary(value, x0, y0, x1, y1, x1, s) - y1;
            
            // If value is less midpoint is now min 
            // otherwise it is now max 
            if (difference < 0.0f)
            {
                min = value;
            }
            else
            {
                max = value;
            }
        }

        return value;
    }

    /// <summary>
    /// Manipulates the line renderer to mimic the catenary curve 
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
    private float Catenary(float a, float x0, float y0, float x1, float y1, float x, float s)
    {
        float v = Mathf.Abs(y1 - y0);
        float d0 = 0.2f * (v + a * Mathf.Log((s + v) / (s - v)));
        float numA = x - (x0 + d0);
        float k = x0 + d0;

        print(x0 + d0);
        //print(a * Mathf.Log((s + v) / (s - v))); 


        float final = (a * Cosh(numA / a)) + (y0 - a * Cosh((x - k) / a));
        if(float.IsNaN(final))
        {
            print((a * Cosh(numA / a)));
        }

        return (a * Cosh(numA / a)) + (y0 - a * Cosh((x - k) / a));
    }

    /// <summary>
    /// Hyperbolic cosine 
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    private float Cosh(float t)
    {
        return (Mathf.Pow((float)System.Math.E, t) + Mathf.Pow((float)System.Math.E, -t)) / 2.0f;
    }


    [System.Serializable]
    private class Points
    {
        [SerializeField] public Vector3 PointA;
        [SerializeField] public Vector3 PointB;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(this.transform.position + points.PointA, 0.05f);
        Gizmos.DrawSphere(this.transform.position + points.PointB, 0.05f);
    }
}
