using System.Collections.Generic;
using UnityEngine;

public class FindPointOnEdge : MonoBehaviour
{
    private float distance;
    private float optimalDistance;
    private Vector3 edgePoint;
    private Vector3 optimalPoint;
    
    public Vector3 FindPoint(Vector3 edgeStart, Vector3 edgeEnd, PointData point)
    {
        bool isHorizontal = false;
        List<float> edgeData = Manager.instance.Helper.IsHorizontal(edgeStart, edgeEnd, ref isHorizontal);
        return FindPoint(edgeData[0], edgeData[1], edgeData[2], point, isHorizontal);
    }

    private Vector3 FindPoint(float permanentValue, float edgeStart, float edgeEnd, PointData point, bool isHorizontal)
    {
        edgePoint =new Vector3();
        optimalPoint = Manager.instance.Helper.GetEdgePoint(isHorizontal, permanentValue, edgeStart);

        optimalDistance = FindDistanceBetweenPoints(point.Position, optimalPoint);
        distance=0;

        for (float i = edgeStart; i <= edgeEnd; i += 0.01f)
        {
            edgePoint = Manager.instance.Helper.GetEdgePoint(isHorizontal, permanentValue, i);
            distance = FindDistanceBetweenPoints(point.Position, edgePoint);

            if (distance < optimalDistance)
            {
                optimalDistance = distance;
                optimalPoint = edgePoint;
            }
        }

        return optimalPoint;
    }
    
    public float FindDistanceBetweenPoints(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
}
