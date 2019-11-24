using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Menu
{
    public class MenuInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerStateUi[] playerPreparationUis;
        private readonly List<PlayerController> _playerControllers = new List<PlayerController>();
        [SerializeField] private TextMeshProUGUI joinTip;
        [SerializeField] private Button playButton;

        public void OnPlayerInputJoined(PlayerInput playerInput)
        {
            PlayerController playerController = playerInput.GetComponent<PlayerController>();
            playerController.onJoined += OnPlayerJoined;
            playerController.onDisconnected += OnPlayerLeft;
            _playerControllers.Add(playerController);
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
            if (playerController.playerId == 0) return;
            playerPreparationUis[playerController.playerId - 1].OnPlayerJoined();
            if (_playerControllers.Count == 2 && _playerControllers.All(x => x.playerId > 0))
            {
                joinTip.enabled = false;
                playButton.interactable = true;
            }
        }

        private void OnPlayerLeft(PlayerController playerController)
        {
            if (playerController.playerId == 0) return;
            playerPreparationUis[playerController.playerId - 1].OnPlayerLeft();
            joinTip.enabled = true;
            playButton.interactable = false;
        }
    }
}