using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Menu : MonoBehaviour
{
    private enum Mode
    {
        Start,
        Pause,
        GameOver
    };

    public VRTK_ControllerEvents controllerEventsLeft;
    public GameObject menu;
    public GameObject menuText;
    private Text text;
    private currentMode Mode = Mode.Start;

    void Start()
    {
        text = menuText.GetComponent<Text>();
        text.text = "Keep the Wheelers from Blowing up your tower!";
        
        TimeManager.Pause();
        controllerEventsLeft.ButtonTwoReleased += ToggleMenu;
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        controllerEventsLeft.ButtonTwoReleased -= ToggleMenu;
        TimeManager.Resume();
    }

    public void Reset()
    {
        Debug.Log("Reset");
        GameManager.Reset();
    }

    private void ToggleMenu(object sender, ControllerInteractionEventArgs e)
    {
        MenuState = !MenuState;
        if(MenuState)
        {
            text = menuText.GetComponent<Text>();
            text.text = "Hmm! Continue or reset the game?";
            //TimeManager.Pause();
        } else
        {
            TimeManager.Resume();
        }
        menu.SetActive(MenuState);
    }

    private void HideMenu()
    {

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
