using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class BlueBullet : Bullet
{
    protected override void Move()
    {
        rigidbody2d.linearVelocity = direction * speed;
    }

    protected override void OnGroundCollision(Collision2D collision)
    {
        SetDirection(Vector2.Reflect(direction, collision.GetContact(0).normal));
        strength--;
    }

    protected override void OnStrength0()
    { 
        Destroy(gameObject);
    }
}
