using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void Rock(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("ROCK");
    }
    public void Paper(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("PAPER");
    }
    public void Scissors(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("SCISSORS");
    }
}
