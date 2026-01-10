using UnityEngine;

public class Paper : MonoBehaviour
{
    public Sprite puzzleSprite;
    public ZoomUIController zoomUI;

    void OnMouseDown()
    {
        zoomUI.ShowZoom(puzzleSprite);
    }
}
