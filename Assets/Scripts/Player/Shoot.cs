using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab = null;
    public float bulletSpeed = 2000f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(original: bulletPrefab,
                                            position: this.transform.position,
                                            rotation: Quaternion.identity);

            bullet.GetComponent<Rigidbody>().velocity = Time.deltaTime * bulletSpeed * this.transform.forward;
        }
    }
}
