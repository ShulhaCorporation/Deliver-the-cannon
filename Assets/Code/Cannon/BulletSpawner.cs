using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

enum MagazineMode
{
    Finite,
    Infinite
}
public class BulletSpawner : MonoBehaviour, IPointerDownHandler
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
    public void OnPointerDown(PointerEventData eventData)
    {
      if(eventData.button == PointerEventData.InputButton.Left)
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

}
