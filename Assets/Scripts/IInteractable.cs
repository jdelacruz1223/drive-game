using System.Collections;
using UnityEngine;

public interface IInteractable
{
    void InteractAction();
    IEnumerator CooldownCoroutine();
}
