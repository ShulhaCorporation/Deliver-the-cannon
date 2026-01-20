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
    private GameObject spawnpoint;
    private Transform spawntransform;
    private BulletSpawnWallChecker wallChecker;
    public InputActionReference shoot;
    private void Start()
    {
     spawntransform = spawnpoint.transform;
     wallChecker = spawnpoint.GetComponent<BulletSpawnWallChecker>();
    }
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
        if(!wallChecker.IsInsideWall)
        {
        Bullet bullet = Instantiate(magazine[0], spawntransform.position, Quaternion.identity);
          bullet.SetStrength(strengths[0]);
          bullet.SetDirection(director.position - bullet.transform.position);
          bullet.SetPlayer(gameObject);
         if(magazineMode == MagazineMode.Finite){
            magazine.RemoveAt(0);
            strengths.RemoveAt(0);
         }
        }
    }
}
