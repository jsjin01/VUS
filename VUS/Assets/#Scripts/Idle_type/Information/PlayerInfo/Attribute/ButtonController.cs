using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public StatUp StatUp;
    public Button attackPowerButton;
    public Button magicPowerButton;
    public Button attackSpeedButton;
    public Button moveSpeedButton;
    public Button strengthButton;
    public Button critChanceButton;
    public Button critDamageButton;

    void Start()
    {
        attackPowerButton.onClick.AddListener(StatUp.IncreaseAttackPower);
        magicPowerButton.onClick.AddListener(StatUp.IncreaseMagicPower);
        attackSpeedButton.onClick.AddListener(StatUp.IncreaseAttackSpeed);
        moveSpeedButton.onClick.AddListener (StatUp.IncreaseMoveSpeed);
        strengthButton.onClick.AddListener (StatUp.IncreaseStrength);
        critChanceButton.onClick.AddListener(StatUp.IncreaseCritChance);
        critDamageButton.onClick.AddListener(StatUp.IncreaseCritDamage);
    }
}
