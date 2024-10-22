using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndPanelController : MonoBehaviour
{
    public Image castingImage;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI clearText;
    
    public void SetCastingImage(Sprite sprite)
    {
        castingImage.sprite = sprite;
    }
    
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ClearText(bool clear)
    {
        if (clear)
        {
            clearText.text = "clear".ToString();
        }
        else
        {
            clearText.text = "Fail".ToString();
        }
    }
}
