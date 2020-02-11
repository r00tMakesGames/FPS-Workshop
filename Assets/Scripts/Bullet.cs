using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float duration = 2f;

    private void Start()
    {
        Invoke(nameof(Kill), duration);
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.CompareTag("Enemy"))
        {
            Destroy(other);
        }
    }
}
