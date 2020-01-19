using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Menu : MonoBehaviour
{
    public VRTK_ControllerEvents controllerEventsLeft;
    public VRTK_ControllerEvents controllerEventsRight;
    //public VRTK_ControllerEvents controllerEvents;
    public GameObject menu;
    public GameObject menuText;
    private Text text;

    bool MenuState = true;

    void Start()
    {
        text = menuText.GetComponent<Text>();
        text.text = "Keep the Wheelers from Blowing up your tower!";
        
        TimeManager.Pause();
    }

    private void OnEnable()
    {
        //controllerEvents.ButtonTwoReleased += ToggleMenu;
        controllerEventsLeft.ButtonTwoReleased += ToggleMenu;
        controllerEventsRight.ButtonTwoReleased += ToggleMenu;
    }
    private void OnDisable()
    {
        //controllerEvents.ButtonTwoReleased -= ToggleMenu;
        controllerEventsLeft.ButtonTwoPressed -= ToggleMenu;
        controllerEventsRight.ButtonTwoPressed -= ToggleMenu;
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
}
