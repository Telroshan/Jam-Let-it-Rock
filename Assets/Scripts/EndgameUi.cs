using TMPro;
using UnityEngine;

public class EndgameUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;

    public void Init(string winner)
    {
        winText.text = winner + " wins";
        gameObject.SetActive(true);
    }
}