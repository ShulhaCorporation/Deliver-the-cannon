using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public void TeleportPlayer(Vector3 position)
    {
       transform.position = position;   
    }
}
