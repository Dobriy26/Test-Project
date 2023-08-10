using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform gunPoint; 
    [SerializeField]
    private GameObject bulletPrefab; 
    [SerializeField]
    private float bulletSpeed = 10f; 
    [SerializeField]
    private float fireRate = 1f; 
    [SerializeField]
    private int bulletDamage = 10; 
    
    private float nextFireTime = 0f; 

    private void Update()
    {
        Aim(); 

        
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    private void Aim()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    private void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        rb.velocity = gunPoint.up * bulletSpeed;
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = bulletDamage;
    }
}
