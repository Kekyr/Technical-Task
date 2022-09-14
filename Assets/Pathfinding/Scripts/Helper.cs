using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private float horizontalSide;
    
    public Vector3 GetEdgePoint(bool isHorizontal, float permanentValue, float changeableValue)
    {
        if (isHorizontal)
        {
            return new Vector3(changeableValue, permanentValue);
        }
        else
        {
            return new Vector3(permanentValue, changeableValue);
        }
    }
    
    public List<float> IsHorizontal(Vector3 start, Vector3 end, ref bool isHorizontal)
    {
        horizontalSide = Mathf.Abs(end.x - start.x);

        if (horizontalSide == 0)
        {
            isHorizontal = false;
            return new List<float>() {start.x, start.y, end.y};
        }

        isHorizontal = true;
        return new List<float>() {start.y, start.x, end.x};
    }

    public static bool ComparePoints(Vector3 point1, Vector3 point2, float tolerance)
    {
        return Mathf.Abs(Vector3.Distance(point1, point2)) <= tolerance;
    }

}
