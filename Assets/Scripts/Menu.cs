using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Menu : MonoBehaviour
{
    public enum Mode
    {
        Start,
        Pause,
        GameOver
    };

    public VRTK_ControllerEvents controllerEventsLeft;
    public GameObject menu;
    public GameObject menuText;
    private Text text;
    private Mode? currentMode;

    void Start()
    {
        controllerEventsLeft.ButtonTwoPressed += ToggleMenu;
        ShowMenu(Mode.Pause); // FIXME
    }

    private void OnEnable()
    {
        TimeManager.Pause();
    }

    private void OnDisable()
    {
        TimeManager.Resume();
    }

    private void Reset()
    {
        GameManager.Reset();
    }

    private void ToggleMenu(object sender, ControllerInteractionEventArgs e)
    {
        if (currentMode == Mode.Start || currentMode == Mode.GameOver)
        {
            return;
        }

        if (currentMode == null)
        {
            ShowMenu(Mode.Pause);
        }
        else
        {
            HideMenu();
        }
    }

    public void HideMenu()
    {
        currentMode = null;
        menu.SetActive(false);
    }

    public void ShowMenu(Mode mode)
    {
        currentMode = mode;

        switch (mode)
        {
            case Mode.Start:
                ShowMenuStart();
                break;

            case Mode.Pause:
                ShowMenuPause();
                break;

            case Mode.GameOver:
                ShowMenuGameOver();
                break;
        }

        menu.SetActive(true);
    }

    private void ShowMenuStart()
    {

    }

    private void ShowMenuPause()
    {

    }

    private void ShowMenuGameOver()
    {

    }
}
