using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private int mouseRaycastDistance = 100;
    public LayerMask mask;
    private Camera cam;
    

    void Start()
    {
        cam = Camera.main;
        // print(camera.name);
    }

    void Update()
    {
        DrawMouseRay();
        CheckMouseClick();
    }

    void DrawMouseRay()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);   
    }
    
    void CheckMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, mouseRaycastDistance, mask))
            {
                hit.collider.TryGetComponent<IInteractable>(out var interactable);
                try
                {
                    interactable.InteractAction();
                }
                catch
                {
                    Debug.Log("Object has no set Interact Action");
                }
                Debug.Log(hit.transform.name);
            }
        }
    }
}
