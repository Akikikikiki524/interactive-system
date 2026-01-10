using UnityEngine;

public class ClickablePaper : MonoBehaviour
{
    public GameObject zoomUIPanel; // 拡大UIパネル

    void OnMouseDown()
    {
        if (zoomUIPanel != null)
        {
            zoomUIPanel.SetActive(true);
        }
    }
}
