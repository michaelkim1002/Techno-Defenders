using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;                   //array of waypoints

    void Awake()
    {
        points = new Transform[transform.childCount];   //points are transforms
        for(int x = 0; x<points.Length;x++)
        {
            points[x] = transform.GetChild(x);          //points are created where enemy moves to the next point
        }
    }
}
