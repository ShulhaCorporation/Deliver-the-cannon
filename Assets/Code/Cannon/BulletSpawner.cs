using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

enum MagazineMode
{
    Finite,
    Infinite
}
public class BulletSpawner : MonoBehaviour
{   
    [SerializeField]
    private List<Bullet> magazine;
    [SerializeField]
    private List<int> strengths;
    [SerializeField]
    private MagazineMode magazineMode;
    [SerializeField]
    private Transform director;
    [SerializeField]
    private Transform spawnpoint;
    public InputActionReference shoot;
    private void OnEnable()
    {
     shoot.action.started += Shoot;   
    }
    private void OnDisable()
    {
        
     shoot.action.started -= Shoot;   
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        Bullet bullet = Instantiate(magazine[0], spawnpoint.position, Quaternion.identity);
          bullet.SetStrength(strengths[0]);
          bullet.SetDirection(director.position - bullet.transform.position);
         if(magazineMode == MagazineMode.Finite){
            magazine.RemoveAt(0);
            strengths.RemoveAt(0);
         }
      
    }
}
