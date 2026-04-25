using UnityEngine;

public class Shooting2D : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.2f;

    private float nextFire;
    private bool facingRight = true;

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            facingRight = true;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            facingRight = false;

        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();

        float direction = facingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(bulletSpeed * direction, 0f);
    }
}
