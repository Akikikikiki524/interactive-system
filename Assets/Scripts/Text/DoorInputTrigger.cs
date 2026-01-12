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

        // ★ Enter確定イベントを登録
        inputField.onSubmit.AddListener(OnSubmitInput);
    }

    void OnMouseDown()
    {
        inputPanel.SetActive(true);
        inputField.text = "";
        inputField.ActivateInputField();
    }

    // ★ Enter が押された瞬間に呼ばれる
    void OnSubmitInput(string input)
    {
        if (input == correctWord)
        {
            clearText.gameObject.SetActive(true);
            inputPanel.SetActive(false);
        }
        else
        {
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}
