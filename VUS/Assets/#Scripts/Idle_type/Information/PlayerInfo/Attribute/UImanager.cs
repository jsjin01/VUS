using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public StatUpgrade playerStats;

    public Button upgradeAttackButton;
    public Button upgradeAttack100Button;
    public Button upgradeMagicButton;
    public Button upgradeMagic100Button;
    public Button upgradeAttackSpeedButton;
    public Button upgradeAttackSpeed100Button;
    public Button upgradeMoveSpeedButton;
    public Button upgradeMoveSpeed100Button; 
    public Button upgradePhysicalStrengthButton;
    public Button upgradePhysicalStrength100Button;
    public Button upgradeCritChanceButton;
    public Button upgradeCritChance100Button;
    public Button upgradeCritDamageButton;
    public Button upgradeCritDamage100Button;

    void Start()
    {
        upgradeAttackButton.onClick.AddListener(() => playerStats.UpgradeAttackPower(1));
        upgradeAttack100Button.onClick.AddListener(() => playerStats.UpgradeAttackPower(100));
        upgradeMagicButton.onClick.AddListener(() => playerStats.UpgradeMagicPower(1));
        upgradeMagic100Button.onClick.AddListener(() => playerStats.UpgradeMagicPower(100));
        upgradeAttackSpeedButton.onClick.AddListener(() => playerStats.UpgradeAttackSpeed(1));
        upgradeAttackSpeedButton.onClick.AddListener(() => playerStats.UpgradeAttackSpeed(100));
        upgradeMoveSpeedButton.onClick.AddListener(() => playerStats.UpgradeMoveSpeed(1));
        upgradeMoveSpeedButton.onClick.AddListener(() => playerStats.UpgradeMoveSpeed(100));
        upgradePhysicalStrengthButton.onClick.AddListener(() => playerStats.UpgradePhysicalStrength(1));
        upgradePhysicalStrengthButton.onClick.AddListener(() => playerStats.UpgradePhysicalStrength(100));
        upgradeCritChanceButton.onClick.AddListener(() => playerStats.UpgradeCritChance(1));
        upgradeCritChanceButton.onClick.AddListener(() => playerStats.UpgradeCritChance(100));
        upgradeCritDamageButton.onClick.AddListener(() => playerStats.UpgradeCritDamage(1));
        upgradeCritDamageButton.onClick.AddListener(() => playerStats.UpgradeCritDamage(100));
    }
}