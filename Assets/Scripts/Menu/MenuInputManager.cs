using System.Linq;
using TMPro;
using UnityEngine;

public class MenuInputManager : MonoBehaviour
{
    [SerializeField] private PlayerPreparationUi[] playerPreparationUis;
    private PlayerController[] _playerControllers;
    [SerializeField] private TextMeshProUGUI joinTip;
    
    private void Awake()
    {
        _playerControllers = FindObjectsOfType<PlayerController>();
        foreach (PlayerController playerController in _playerControllers)
        {
            playerController.onJoined += () => OnPlayerJoined(playerController);
        }
    }

    private void OnPlayerJoined(PlayerController playerController)
    {
        playerPreparationUis[playerController.playerId - 1].OnPlayerJoined();
        if (_playerControllers.All(x => x.playerId > 0))
        {
            joinTip.text = "";
        }
    }
}