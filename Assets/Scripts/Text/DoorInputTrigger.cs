using UnityEngine;
using TMPro;

public class DoorInputTrigger : MonoBehaviour
{
    public GameObject inputPanel;
    public TMP_InputField inputField;
    public TMP_Text clearText;

    [SerializeField]
    private string correctWord = "open";

    void Start()
    {
        inputPanel.SetActive(false);
        clearText.gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        inputPanel.SetActive(true);
        inputField.text = "";
        inputField.ActivateInputField(); // 自動フォーカス
    }

    void Update()
    {
        if (!inputPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        if (inputField.text == correctWord)
        {
            clearText.gameObject.SetActive(true);
            inputPanel.SetActive(false);
        }
        else
        {
            inputField.text = "";
        }
    }
}
