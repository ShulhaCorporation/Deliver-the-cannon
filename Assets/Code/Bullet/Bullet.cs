using System.Text;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public abstract class Bullet : MonoBehaviour
{   
    [SerializeField]
    protected Rigidbody2D rigidbody2d;
    [SerializeField]
    protected int strength;
    [SerializeField]
    protected float speed;
    protected Vector3 direction;
    protected GameObject player;
    private bool lockUpdate = false;
    void Update()
    {
        if(strength <= 0 && !lockUpdate)
        {
         lockUpdate = true;
         OnStrength0();   
        }
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
        Move();
    }
    public void SetStrength(int strength)
    {
     this.strength = strength;   
    }
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
    protected abstract void Move();
    protected abstract void OnStrength0();
    protected abstract void OnGroundCollision(Collision2D collision);
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Player"))
        {
            OnGroundCollision(collision);
        }
    }
}
