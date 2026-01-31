using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneManagement : MonoBehaviour
{

    ///// Necessary references/variables \\\\\
    // Keep track of the currently loaded scene.
    public string currentScene = null;
    // Loading scene to be used as intermediary.
    public string loadingScene = "LoadingScene";
    // Menu scene first loaded.
    public string menuScene = "MenuScene";
    // Shows buttons that take player to selected level scene.
    public string levelSelectionScene = "LevelSelectionScene";
    // FIXME (Need some levels created).
    public string[] levels = { "LevelOneScene", }; 


    ///// Initialize Bootstrap \\\\\
    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);

    }


    ///// Functions \\\\\\
    void Start()
    {

        StartCoroutine(ChangeScenes(menuScene));

    }


    // Function for when player presses 'Play' on Main Menu.
    public void StartPlay() => ChangeScenesHelper(levelSelectionScene);

    // Function for when player presses 'Quit' on Main Menu.
    public void Quit()
    {

        // Check if in editor or application to exit appropriately. 
        // Preprocessor, so will not be included in final application.
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();

        #endif

    }

    // Function for when player returns to main menu.
    public void ReturnMainMenu() => ChangeScenesHelper(menuScene);

    // Load Level 1.
    public void LevelOne() => ChangeScenesHelper(levels[0]);


    // Call this function when user presses button to 
    // load a new level.
    void ChangeScenesHelper(string selectedScene) => StartCoroutine(ChangeScenes(selectedScene));


    // Coroutine for loading and unloading levels.
    IEnumerator ChangeScenes(string selectedScene)
    {

        // Loads and sets loadingScene as active.
        yield return SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadingScene));

        // Check to see if there is a current scene active needing removal.
        // Implemented as a safeguard to reduce ambiguity of what scene will be unloaded.
        if (!string.IsNullOrEmpty(currentScene))
        {

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(currentScene));

        }
        
        // Loads and sets selectedScene (target scene) as active.
        yield return SceneManager.LoadSceneAsync(selectedScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(selectedScene));

        // Unloads loadingScene.
        yield return SceneManager.UnloadSceneAsync(loadingScene);

        // Updates name of the currently active scene.
        currentScene = selectedScene;

    }

}
