using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Menu
{
    public class InputCleaner : MonoBehaviour
    {
        private InputSystemUIInputModule _inputModule;

        private void Awake()
        {
            _inputModule = GetComponent<InputSystemUIInputModule>();
        }

        private void OnDestroy()
        {
            _inputModule.actionsAsset = null;
            foreach (PlayerInput playerInput in FindObjectsOfType<PlayerInput>())
            {
                playerInput.uiInputModule = null;
            }
        }
    }
}