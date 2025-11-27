using Unity.VisualScripting;
using UnityEngine;

public class PauseManager : MonoBehaviour

{
    public bool paused;

    public void ToggelPause()
    {
        paused = !paused;
        EventManager.InvokeTogglePause(paused);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggelPause();
        }
    }
}