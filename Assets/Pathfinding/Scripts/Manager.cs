using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance { get; private set; }

    public FindPointOnEdge FindPointOnEdge;
    public Helper Helper;
    public CheckPoints CheckPoints;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        FindPointOnEdge = GetComponent<FindPointOnEdge>();
        Helper = GetComponent<Helper>();
        CheckPoints = GetComponent<CheckPoints>();
    }
}
