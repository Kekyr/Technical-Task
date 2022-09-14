using UnityEngine;

public class ChangeCanvasGroup:MonoBehaviour, IChangeCanvasGroup
{
    public void TurnOnAndOffMouseEvents(CanvasGroup canvasGroup,bool turn)
    {
        canvasGroup.blocksRaycasts = !turn;
    }
}