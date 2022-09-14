using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Edge
{
    [field: SerializeField]
    public Rectangle First { get; private set; }
    
    [field: SerializeField]
    public Rectangle Second { get; private set; }
    
    [field: SerializeField]
    public PointData Start { get; private set; }
    
    [field: SerializeField]
    public PointData End { get; private set; }

    
    public Edge(Vector2 min1, Vector2 min2, Vector2 max1, Vector2 max2, PointData start, PointData end)
    {
        First = new Rectangle(min1, max1);
        Second = new Rectangle(min2, max2);
        Start = start;
        End = end;

        if (CheckRectangles() || Helper.ComparePoints(start.Position, end.Position,0.01f)|| !CheckEdgeOnRectangles(First, Second, start, end))
        {
            Debug.Log("CheckRectangles: "+CheckRectangles());
            Debug.Log("ComparePoints: "+Helper.ComparePoints(start.Position, end.Position,0.01f));
            Debug.Log("CheckEdgeOnRectangles: "+CheckEdgeOnRectangles(First, Second, start, end));
            Debug.Log("Вы ввели неверные значения при создании ребра пересечения!");
            Start= new PointData(default(Vector3));
            End = new PointData(default(Vector3));
        }
    }

    private bool CheckRectangles()
    {
        if (First.Min == default(Vector2) && First.Max == default(Vector2) ||
            Second.Min == default(Vector2) && Second.Max == default(Vector2))
        {
            return true;
        }

        return false;
    }
    
    private bool CheckEdgeOnRectangles(Rectangle first, Rectangle second, PointData start, PointData end)
    {
        if (Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(first, new List<PointData>(){start,end}) &&
            Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(second, new List<PointData>(){start,end}))
        {
            return true;
        }
        
        return false;
    }
    
   
}