using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;

    private void OnEnable()
    {
        EventManager.TogglePause += TogglePauseMenu;
    }

    private void OnDisable()
    {
        EventManager.TogglePause -= TogglePauseMenu;
    }
    public void TogglePauseMenu(bool paused)
    {
        pausemenu.SetActive(paused);
    }

}
