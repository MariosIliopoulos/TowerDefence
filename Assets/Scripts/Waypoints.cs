using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    //public int branchPosition = 0;
    public int[] branchAmount;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
