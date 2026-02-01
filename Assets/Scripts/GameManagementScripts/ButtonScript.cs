using UnityEngine;

public class CanvasUI : MonoBehaviour
{

    // Refernce to the Scene_Manager script.
    private SceneManagement sceneManagement;
    private PauseManagement pauseManagement;

    // At runtime, looks for the Scene_Manager.
    private void Awake()
    {

        // Looks for first SceneManagement scene available.
        sceneManagement = (SceneManagement)FindFirstObjectByType(typeof(SceneManagement));
        pauseManagement = (PauseManagement)FindFirstObjectByType(typeof(PauseManagement));
    
    }

    // Function for when player presses 'Play' on Main Menu.
    public void StartPlay() => sceneManagement.StartPlay();

    // Function for when player presses 'Quit' on Main Menu.
    public void Quit() => sceneManagement.Quit();

    // Function for when player returns to main menu.
    public void ReturnMainMenu() => sceneManagement.ReturnMainMenu();

    // Function for when player pauses.
    public void Pause() => sceneManagement.Pause();

    // Function for when player resums.
    public void Resume() => sceneManagement.Resume();

    // Load Level 1.
    public void LevelOne() => sceneManagement.LevelOne();

    

}

