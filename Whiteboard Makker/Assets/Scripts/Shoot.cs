using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ObjectPooler bulletPool;

    public int bulletSpeed = 10;    
   
    void Update() // to keep checking for the mouse button to go down
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //to know which direction to shoot
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;   
            
       GameObject bullet = bulletPool.GetPooledObject(); 
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }

}
