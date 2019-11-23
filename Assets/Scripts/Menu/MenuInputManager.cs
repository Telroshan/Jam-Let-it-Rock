using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu
{
    public class MenuInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerStateUi[] playerPreparationUis;
        private PlayerController[] _playerControllers;
        [SerializeField] private TextMeshProUGUI joinTip;
        [SerializeField] private Button playButton;

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
                playButton.interactable = true;
            }
        }

        private void OnPlayerLeft(PlayerController playerController)
        {
            playerPreparationUis[playerController.playerId - 1].OnPlayerLeft();
            joinTip.enabled = true;
            playButton.interactable = false;
        }
    }
}