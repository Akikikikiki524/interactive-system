using UnityEngine;
using UnityEngine.UI;

public class ZoomUIController : MonoBehaviour
{
    public GameObject zoomPanel;
    public Image zoomImage;
    public PlayerPOV playerPOV;

    public void ShowZoom(Sprite sprite)
    {
        zoomPanel.SetActive(true);
        zoomImage.sprite = sprite;

        // 視点停止
        playerPOV.enabled = false;

        // カーソル解放
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseZoom()
    {
        zoomPanel.SetActive(false);

        // 視点再開
        playerPOV.enabled = true;

        // カーソル再ロック
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
