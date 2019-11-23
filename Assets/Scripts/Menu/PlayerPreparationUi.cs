using UnityEngine;
using UnityEngine.UI;

public class PlayerPreparationUi : MonoBehaviour
{
    [SerializeField] private Image joinedImage;

    public void OnPlayerJoined()
    {
        joinedImage.gameObject.SetActive(true);
    }

    public void OnPlayerLeft()
    {
        joinedImage.gameObject.SetActive(false);
    }
}