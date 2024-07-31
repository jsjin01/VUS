using UnityEngine;
using UnityEngine.UI;

public class NicknameManagerWithPrefs : MonoBehaviour
{
    public InputField nicknameInputField;
    public Text nicknameDisplayText;
    public Button setNicknameButton;

    private void Start()
    {
        // ����� �г��� �ҷ�����
        if (PlayerPrefs.HasKey("Nickname"))
        {
            string savedNickname = PlayerPrefs.GetString("Nickname");
            nicknameDisplayText.text = "Nickname: " + savedNickname;
            nicknameInputField.text = savedNickname;
        }

        setNicknameButton.onClick.AddListener(SetNickname);
    }

    private void SetNickname()
    {
        string nickname = nicknameInputField.text;
        if (!string.IsNullOrEmpty(nickname))
        {
            nicknameDisplayText.text = "Nickname: " + nickname;
            PlayerPrefs.SetString("Nickname", nickname);
            PlayerPrefs.Save();
        }
    }
}