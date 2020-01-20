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
    public GameObject textMenu;
    public GameObject buttonTop;
    public GameObject buttonBottom;
    private Mode? currentMode;

    void Start()
    {
        controllerEventsLeft.ButtonTwoPressed += ToggleMenu;
        // delay showing of menu, so game is not paused immediately
        // otherwise the pointer doesn't work
        Timer.Register(0.1f, () => { ShowMenuStart(); });
    }

    public void HideMenu()
    {
        currentMode = null;
        menu.SetActive(false);
        TimeManager.Resume();
    }

    public void ShowMenuStart()
    {
        textMenu.GetComponent<Text>().text = "Welcome to Tower Defense!\n\nDestroy the Wheelers with your gun\nbefore they blow up your bunker!";
        buttonTop.GetComponentInChildren<Text>().text = "Start";
        buttonTop.SetActive(true);
        buttonBottom.SetActive(false);
        ShowMenu(Mode.Start);
    }

    public void ShowMenuPause(int wheelersDestroyedCount)
    {
        textMenu.GetComponent<Text>().text = $"PAUSED\n\nYou have destroyed {wheelersDestroyedCount} Wheelers until now.";
        buttonTop.GetComponentInChildren<Text>().text = "Continue";
        buttonTop.SetActive(true);
        buttonTop.GetComponentInChildren<Text>().text = "Reset";
        buttonBottom.SetActive(true);
        ShowMenu(Mode.Pause);
    }

    public void ShowMenuGameOver(int wheelersDestroyedCount)
    {
        textMenu.GetComponent<Text>().text = $"GAME OVER\n\nYou were blown up!\nBut you managed to destroy {wheelersDestroyedCount} Wheelers.";
        buttonTop.GetComponentInChildren<Text>().text = "Reset";
        buttonTop.SetActive(true);
        buttonBottom.SetActive(false);
        ShowMenu(Mode.GameOver);
    }

    private void ToggleMenu(object sender, ControllerInteractionEventArgs e)
    {
        if (currentMode == Mode.Start || currentMode == Mode.GameOver)
        {
            return;
        }

        if (currentMode == null)
        {
            ShowMenuPause(GameManager.WheelersDestroyedCount);
        }
        else
        {
            HideMenu();
        }
    }

    private void ShowMenu(Mode mode)
    {
        currentMode = mode;
        menu.SetActive(true);
        TimeManager.Pause();
    }

    private void Reset()
    {
        GameManager.Reset();
    }
}
