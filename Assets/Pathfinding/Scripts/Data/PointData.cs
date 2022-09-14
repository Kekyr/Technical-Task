using UnityEngine;

[System.Serializable]
public class PointData 
{
    [field: SerializeField]
    public Vector3 Position { get; private set; }
    
    public bool IsIncluded { get; set; }

    public PointData(Vector3 position)
    {
        Position = position;
        IsIncluded = false;
    }

    public PointData(Vector3 position, bool isIncluded)
    {
        Position = position;
        IsIncluded = isIncluded;
    }
}
