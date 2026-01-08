using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    void Update()
    {
       Vector3 mousePos = Mouse.current.position.ReadValue(); 
       mousePos.z = Camera.main.nearClipPlane;
       Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, worldMousePos - transform.position));  
    }
}
