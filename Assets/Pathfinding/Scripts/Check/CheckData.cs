using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CheckData
{
    public static bool VerifyData(PointData point1, PointData point2, IEnumerable<Edge> edges, List<Rectangle> rectangles)
    {
        if (!CheckEdges(edges) && CheckNumberOfEdges(edges) && CheckPoints(point1, point2, edges, rectangles))
        {
            return true;
        }

        return false;
    }

    private static bool CheckPoints(PointData point1, PointData point2, IEnumerable<Edge> edges, List<Rectangle> rectangles)
    {
        if (CheckPoint.VerifyPoint(point1, edges, rectangles) && CheckPoint.VerifyPoint(point2, edges, rectangles) &&
            !CheckPoint.CheckPointsOnRectangles(point1, point2, rectangles))
        {
            return true;
        }

        return false;
    }

    private static bool CheckEdges(IEnumerable<Edge> edges)
    {
        foreach (Edge edge in edges)
        {
            if (edge.Start.Position == default(Vector3) && edge.End.Position == default(Vector3))
            {
                return true;
            }
        }
        return false;
    }

    private static bool CheckNumberOfEdges(IEnumerable<Edge> edges)
    {
        return edges.Count() > 0 && edges.Count() < 3;
    }
}