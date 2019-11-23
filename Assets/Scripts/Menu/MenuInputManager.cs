using System.Linq;
using TMPro;
using UnityEngine;

namespace Menu
{
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
                playerController.onJoined += OnPlayerJoined;
                playerController.onDisconnected += OnPlayerLeft;
            }
        }

        private void OnDestroy()
        {
            foreach (PlayerController playerController in _playerControllers)
            {
                playerController.onJoined -= OnPlayerJoined;
                playerController.onDisconnected -= OnPlayerLeft;
            }
        }

        private void OnPlayerJoined(PlayerController playerController)
        {
            playerPreparationUis[playerController.playerId - 1].OnPlayerJoined();
            if (_playerControllers.All(x => x.playerId > 0))
            {
                joinTip.enabled = false;
            }
        }

        private void OnPlayerLeft(PlayerController playerController)
        {
            playerPreparationUis[playerController.playerId - 1].OnPlayerLeft();
            joinTip.enabled = true;
        }
    }
}