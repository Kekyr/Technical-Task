using UnityEngine;

[System.Serializable]
public struct Rectangle
{
    [field: SerializeField]
    public Vector2 Min { get; private set; }
    
    [field: SerializeField]
    public Vector2 Max { get; private set; }

    public Rectangle(Vector2 min, Vector2 max)
    {
        Min = min;
        Max = max;
        
        float side1 = Mathf.Abs(max.x - min.x);
        float side2 = Mathf.Abs(max.y - min.y);
        
        if (side1 == 0 || side2 == 0 || side1 == side2)
        {
            Debug.Log("Вы ввели неверные данные при создании прямоугольника!");
            Min = default(Vector2);
            Max = default(Vector2);
        }
    }
    
}