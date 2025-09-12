using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    // 턴 패널
    [SerializeField] private GameObject playerATurnPanel;
    [SerializeField] private GameObject playerBTurnPanel;

    // 급수 패널
    [SerializeField] private TextMeshProUGUI playerARateTierText;
    [SerializeField] private TextMeshProUGUI playerBRateTierText;


    public enum GameTurnPanelType { None, ATurn, BTurn }

    public void OnClickBackButton() {
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?", () => {
            GameManager.Instance.ChangeToMainScene();
        });
    }

    public void SetGameTurnPanel(GameTurnPanelType type) {
        switch (type) {
            case GameTurnPanelType.None:
                playerATurnPanel.SetActive(false);
                playerBTurnPanel.SetActive(false);
                break;
            case GameTurnPanelType.ATurn:
                playerATurnPanel.SetActive(true);
                playerBTurnPanel.SetActive(false);
                break;
            case GameTurnPanelType.BTurn:
                playerATurnPanel.SetActive(false);
                playerBTurnPanel.SetActive(true);
                break;
        }
    }

    public void SetPlayerRateTierPanel(GameTurnPanelType type, int rateTier) {
        switch (type) {
            case GameTurnPanelType.None:
                break;
            case GameTurnPanelType.ATurn:
                playerARateTierText.text = $"{rateTier.ToString()} 급";
                break;
            case GameTurnPanelType.BTurn:
                playerBRateTierText.text = $"{rateTier.ToString()} 급";
                break;
        }
    }
}
