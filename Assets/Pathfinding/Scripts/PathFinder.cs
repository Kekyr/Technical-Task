using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour, IPathFinder
{
    [SerializeField] private Vector3 _a;
    [SerializeField] private Vector3 _c;
    [SerializeField] private List<Edge> _edges = new List<Edge>();
    
    private float _distance=0;
    private List<Rectangle> _rectangles = new List<Rectangle>();
    

    private void Start()
    {
        for (int i = 0; i < _edges.Count(); i++)
        {
            _edges[i] = new Edge(_edges[i].First.Min, _edges[i].Second.Min,
                _edges[i].First.Max, _edges[i].Second.Max,
                _edges[i].Start, _edges[i].End);
        }

        PointData a = new PointData(_a);
        PointData c = new PointData(_c);

        List<Vector3> result=(List<Vector3>)GetPath(a, c, _edges);
        
        foreach (Vector3 point in result)
        {
            Debug.Log(point);
        }
    }


    public IEnumerable<Vector3> GetPath(PointData A, PointData C, IEnumerable<Edge> edges) // A- начало пути, принадлежит одному из прямоугольников C-конец пути,принадлежит одному из прямоугольников edges-ребра пересечения
    {
        if (CheckOutData(A, C, edges))
        {
            Edge edgeA = FindEdgeOfPoint(A, edges);
            Edge edgeC = FindEdgeOfPoint(C, edges);
            Vector3 a = Manager.instance.FindPointOnEdge.FindPoint(edgeA.Start.Position, edgeA.End.Position, A);
            Vector3 c = Manager.instance.FindPointOnEdge.FindPoint(edgeC.Start.Position, edgeC.End.Position, C);
            Vector3 b = FindEndOfLineSegment(A, a);
            Vector3 d = FindEndOfLineSegment(C, c);
            Vector3 B = FindIntersectionPoint(a, b, c, d);
            List<Vector3> path = new List<Vector3>() {A.Position, B, C.Position};
            return path;
        }

        return null;
    }
    
    private bool CheckOutData(PointData point1, PointData point2, IEnumerable<Edge> edges)
    {
        if (CheckData.VerifyData(point1,point2, edges,_rectangles))
        {
            return true;
        }

        return false;
    }
    
    private Edge FindEdgeOfPoint(PointData point, IEnumerable<Edge> edges)
    {
        foreach(Rectangle rectangle in _rectangles)
        {
            foreach(Edge edge in edges)
            {
                if (Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){point}) &&
                    Manager.instance.CheckPoints.CheckPointOrEdgeOnRectangle(rectangle, new List<PointData>(){edge.Start,edge.End}))
                {
                    return edge;
                }
            }
        }

        return default(Edge);
    }

    private Vector3 FindEndOfLineSegment(PointData origin, Vector3 partOfLineSegment)
    {
        Vector3 direction = (partOfLineSegment - origin.Position).normalized;
        Ray ray = new Ray(origin.Position, direction);
        Debug.DrawRay(origin.Position,direction*_distance,Color.red,100);
        return ray.GetPoint(_distance);
    }
    
    private Vector3 FindIntersectionPoint(Vector3 a, Vector3 b, Vector3 c, Vector3 d1)
    {
        Vector3 r = b - a;
        Vector3 s = d1 - c;

        float d2 = r.x * s.y - r.y * s.x;
        float u = ((c.x - a.x) * r.y - (c.y - a.y) * r.x) / d2;
        float t = ((c.x - a.x) * s.y - (c.y - a.y) * s.x) / d2;
        
        return a + t * r;
    }










}