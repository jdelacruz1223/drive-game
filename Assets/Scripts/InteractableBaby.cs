using System.Collections;
using UnityEngine;

public class InteractableBaby : MonoBehaviour, IInteractable
{
    [SerializeField] private float cooldownDuration = 1f;
    private bool isOnCooldown = false;
    public void InteractAction()
    {
        if (isOnCooldown) // time-gating input for coroutines
        {
            Debug.Log("On cooldown!");
            return;
        } 
        Debug.Log("Interacted with Baby");
        StartCoroutine(CooldownCoroutine());
    }
    
    public IEnumerator CooldownCoroutine()
    {
        // add triggering anything here
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }
}
