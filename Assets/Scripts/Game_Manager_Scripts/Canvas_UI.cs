using UnityEngine;

public class Canvas_UI_Script : MonoBehaviour
{

    // Refernce to the Scene_Manager script.
    private Scene_Manager scene_manager;

    // At runtime, looks for the Scene_Manager.
    private void Awake()
    {

        scene_manager = (Scene_Manager)FindFirstObjectByType(typeof(Scene_Manager));
    
    }

    // Function for when player presses 'Play' on Main Menu.
    public void startPlay()
    {

        scene_manager.startPlay();

    }

    // Function for when player returns to main menu.
    public void returnMainMenu()
    {

        scene_manager.returnMainMenu();

    }

    // Load Level 1.
    public void levelOne()
    {

        scene_manager.levelOne();

    }
}
