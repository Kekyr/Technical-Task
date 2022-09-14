using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public CheckPointsHelper CheckPointsHelper;
    
    private float distance;
    private float optimalDistance;
    private Vector3 edgePoint;
    private bool result;
    private Vector3 optimalPoint;

    private void Awake()
    {
        CheckPointsHelper = GetComponent<CheckPointsHelper>();
    }

    public bool CheckPointOrEdgeOnRectangle(Rectangle rectangle, List<PointData> pointDatas)
    {
        Vector2 min1 = rectangle.Min; 
        Vector2 max1 = rectangle.Max; 


        Vector2 min2 = new Vector2(max1.x, min1.y); 
        Vector2 max2 = new Vector2(min1.x, max1.y);  

        return CheckPointOrEdgeOnRectangleEdges(min1, max1, min2, max2, pointDatas);
    }


    private bool CheckPointOrEdgeOnRectangleEdges(Vector2 min1, Vector2 max1, Vector2 min2, Vector2 max2,
        List<PointData> pointDatas)
    {
        if (CheckPointOrEdgeOnRectangleEdge(min1, min2, pointDatas) || 
            CheckPointOrEdgeOnRectangleEdge(max2, max1, pointDatas) || 
            CheckPointOrEdgeOnRectangleEdge(min2, max1, pointDatas) || 
            CheckPointOrEdgeOnRectangleEdge(min1, max2, pointDatas)) 
        {
            return true;
        }

        return false;
    }

    public bool CheckPointOrEdgeOnRectangleEdge(Vector2 edgeStart, Vector2 edgeEnd, List<PointData> pointDatas)
    {
        bool isHorizontal = false;
        List<float> edgeData = Manager.instance.Helper.IsHorizontal(edgeStart, edgeEnd, ref isHorizontal);
        return CheckPointsOnEdge(edgeData[0], edgeData[1], edgeData[2], pointDatas, isHorizontal);
    }

    private bool CheckPointsOnEdge(float permanentValue, float edgeStart, float edgeEnd, List<PointData> pointDatas,
        bool isHorizontal)
    {
        CheckPointsHelper.RefreshList(pointDatas);

        edgePoint = new Vector3();

        for (float i = edgeStart; i <= edgeEnd; i += 0.01f)
        {
            edgePoint = Manager.instance.Helper.GetEdgePoint(isHorizontal, permanentValue, i);

            foreach (PointData pointData in pointDatas)
            {
                CheckPointsHelper.ChangeBool(pointData, edgePoint);
            }
        }

        return CheckPointsHelper.CheckBools(pointDatas);
    }
}