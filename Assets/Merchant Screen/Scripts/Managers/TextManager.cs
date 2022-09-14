using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour, ITextManager
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    
    public void ChangeText(int text)
    {
        _textMeshPro.text = text.ToString();
    }
}
