using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointsHelper : MonoBehaviour
{
    private bool result;
    
    public void ChangeBool(PointData pointData, Vector3 point)
    {
        if (!pointData.IsIncluded)
        {
            pointData.IsIncluded = Helper.ComparePoints(pointData.Position, point,0.01f);
        }
    }

    public void RefreshList(List<PointData> pointDatas)
    {
        foreach (PointData pointData in pointDatas)
        {
            pointData.IsIncluded = false;
        }
    }

    public bool CheckBools(List<PointData> pointDatas)
    {
        result = pointDatas[0].IsIncluded;

        return MakeResult(result, pointDatas);
    }

    public bool MakeResult(bool result, List<PointData> pointDatas)
    {
        for (int i = 0; i < pointDatas.Count(); i++)
        {
            result = result && pointDatas[i].IsIncluded;
        }

        return result;
    }
}
