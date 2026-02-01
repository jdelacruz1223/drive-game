using System;
using UnityEngine;

public class PauseManagement : MonoBehaviour
{

    // Events/Signals for letting those that need
    // to know about pause state.
    public static Action OnPaused;
    public static Action OnResumed;

    // Contains reference to pause menu panel.
    [SerializeField] GameObject panel;

    // Function for when player pauses.
    public void Pause()
    {

        Time.timeScale = 0;
        OnPaused?.Invoke();
        panel.SetActive(true);

    }

    // Function for when player resumes.
    public void Resume()
    {

        Time.timeScale = 1;
        OnResumed?.Invoke();
        panel.SetActive(false);

    }

}
