using UnityEngine;

public class BulletSpawnWallChecker : MonoBehaviour
{
   private bool isInsideWall = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("wall"))
        {
            isInsideWall = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            isInsideWall = false;       
        }        
    }
    public bool IsInsideWall => isInsideWall;
}
