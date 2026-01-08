using System.Collections;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{   
    [SerializeField]
    private float time;
    void Start()
    {
      StartCoroutine(DestroyAfterSeconds(time));
    }
  IEnumerator DestroyAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);   
    } 
}
