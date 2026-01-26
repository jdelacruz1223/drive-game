using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] private int mouseRaycastDistance = 100;
    public LayerMask mask;
    private Camera camera;
    

    void Start()
    {
        camera = Camera.main;
        print(camera.name);
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
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);   
    }
    
    void CheckMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
