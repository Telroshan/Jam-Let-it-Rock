using UnityEngine;

public class MenuInputManager : MonoBehaviour
{
    [SerializeField] private PlayerPreparationUi[] playerPreparationUis;

    private void Awake()
    {
        foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
        {
            playerController.onJoined += () => OnPlayerJoined(playerController);
        }
    }

    private void OnPlayerJoined(PlayerController playerController)
    {
        playerPreparationUis[playerController.playerId - 1].OnPlayerJoined();
    }
}