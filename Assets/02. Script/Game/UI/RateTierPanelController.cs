using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GameUIController;

public class RateTierPanelController : MonoBehaviour
{
    // 급수 패널
    [SerializeField] private TextMeshProUGUI playerARateTierText;
    [SerializeField] private TextMeshProUGUI playerBRateTierText;

    // 급수 경험치 텍스트
    [SerializeField] private TextMeshProUGUI playerATierEXPText;
    [SerializeField] private TextMeshProUGUI playerBTierEXPText;

    // 급수 경험치 바
    [SerializeField] private Slider playerATierEXPBar;
    [SerializeField] private Slider playerBTierEXPBar;

    public void SetPlayerRateTierPanel(GameTurnPanelType type, int rateTier, int currentEXP) {
        var requireExp = rateTier >= 10 ?
            Constants.minTierExp : rateTier >= 5 ?
            Constants.middleTierExp : Constants.maxTierExp; // 필요 경험치

        switch (type) {
            case GameTurnPanelType.None:
                break;
            case GameTurnPanelType.ATurn:
                // 값 초기화
                playerARateTierText.text = $"{rateTier.ToString()} 급";
                playerATierEXPText.text = $"다음 레벨까지 {requireExp - currentEXP}";
                playerATierEXPBar.value = (float)currentEXP / requireExp;

                // 활성화
                playerARateTierText.gameObject.SetActive(true);
                playerATierEXPBar.gameObject.SetActive(true);
                break;
            case GameTurnPanelType.BTurn:
                // 값 초기화
                playerBRateTierText.text = $"{rateTier.ToString()} 급";
                playerBTierEXPText.text = $"다음 레벨까지 {requireExp - currentEXP}";
                playerBTierEXPBar.value = (float)currentEXP / requireExp;

                // 활성화
                playerBRateTierText.gameObject.SetActive(true);
                playerBTierEXPBar.gameObject.SetActive(true);
                break;
        }
    }
}
