using UnityEngine;

public class CanvasUI : MonoBehaviour
{

    // Refernce to the Scene_Manager script.
    private SceneManagement sceneManagement;

    // At runtime, looks for the Scene_Manager.
    private void Awake()
    {

        // Looks for first SceneManagement scene available.
        sceneManagement = (SceneManagement)FindFirstObjectByType(typeof(SceneManagement));
    
    }

    // Function for when player presses 'Play' on Main Menu.
    public void StartPlay() => sceneManagement.StartPlay();

    // Function for when player returns to main menu.
    public void ReturnMainMenu() => sceneManagement.ReturnMainMenu();

    // Load Level 1.
    public void LevelOne() => sceneManagement.LevelOne();

}
