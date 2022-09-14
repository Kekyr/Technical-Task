using System.Collections.Generic;
using UnityEngine;

public interface IPathFinder
{
    IEnumerable<Vector3> GetPath(PointData A, PointData C, IEnumerable<Edge> edges);
}
