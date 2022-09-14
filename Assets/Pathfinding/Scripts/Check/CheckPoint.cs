using System.Collections.Generic;
using System.Linq;

public static class CheckPoint 
{
    
    public static bool VerifyPoint(PointData point, IEnumerable<Edge> edges, List<Rectangle> rectangles)
    {
        AddRectangles(edges,rectangles);


        if (CheckPointOnRectangles(point, rectangles) && CheckPointAndEdgeOnRectangleEdge(rectangles, edges, point) &&
            !CheckPointOnRectangleMediator(point, rectangles, edges))
        {
            return true;
        }

        return false;
    }

     private static void AddRectangles(IEnumerable<Edge> edges, List<Rectangle> rectangles)
     {
         foreach (Edge edge in edges)
         {
             rectangles.Add(edge.First);
             rectangles.Add(edge.Second);
         }
     }
     
     public static bool CheckPointsOnRectangles(PointData point1, PointData point2, IEnumerable<Rectangle> rectangles)
     {
         foreach (Rectangle rectangle in rectangles)
         {
             if (!Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){point1,point2}))
             {
                 return false;
             }
         }

         return true;
     }

    private static bool CheckPointOnRectangleMediator(PointData point, IEnumerable<Rectangle> rectangles, IEnumerable<Edge> edges)
    {
        if (edges.Count() == 2)
        {
            return Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(FindRectangleMediator(rectangles, edges), new List<PointData>(){point});
        }

        return false;
    }

    private static Rectangle FindRectangleMediator(IEnumerable<Rectangle> rectangles, IEnumerable<Edge> edges)
    {
        int Counter = 0;
        foreach (Rectangle rectangle in rectangles)
        {
            foreach (Edge edge in edges)
            {
                if (Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){edge.Start,edge.End}))
                {
                    Counter++;
                }
            }

            if (Counter == edges.Count())
            {
                return rectangle;
            }
            else
            {
                Counter = 0;
            }
        }

        return default(Rectangle);
    }

    private static bool CheckPointAndEdgeOnRectangleEdge(IEnumerable<Rectangle> rectangles, IEnumerable<Edge> edges, PointData point)
    {
        foreach (Rectangle rectangle in rectangles)
        {
            foreach (Edge edge in edges)
            {
                if (!Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){edge.Start,edge.End,point}))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool CheckPointOnRectangles(PointData point, IEnumerable<Rectangle> rectangles)//????? //A
    {
        foreach (Rectangle rectangle in rectangles)
        {
            if (Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){point}))
            {
                return true;
            }
        }

        return false;
    }
}
