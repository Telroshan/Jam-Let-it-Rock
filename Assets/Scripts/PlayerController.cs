using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Move _selectedMove = Move.None;
    public int score = 0;

    public Move GetMove()
    {
        if (_selectedMove != Move.None) return _selectedMove;
        return (Move) Random.Range((int) Move.Rock, (int) Move.Scissors + 1);
    }

    public void BeginTurn()
    {
        _selectedMove = Move.None;
    }

    public void Rock(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("ROCK");
        _selectedMove = Move.Rock;
    }

    public void Paper(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("PAPER");
        _selectedMove = Move.Paper;
    }

    public void Scissors(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("SCISSORS");
        _selectedMove = Move.Scissors;
    }
}