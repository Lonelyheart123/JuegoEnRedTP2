using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CustomUpdater
{
    public float speed;
    public float turnSpeed;
    public int maxHealth;
    public GameObject bulletPrefab;
    public Transform spawnBullet;
    public Transform respawnPoint;
    public ObjectPool projectilePoolReference;
    private int currentHealth;
    private Rigidbody rb;


    private void Awake()
    {
        Cursor.visible = false;
    }
    private void Start()
    {
        UpdateManagerGameplay.Instance.Add(this);
        rb = GetComponent<Rigidbody>();
    }

    public override void Tick()
    {
        Move();
        Shoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>();
            Die();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal1");
        float verticalInput = Input.GetAxisRaw("Vertical1");

        if (horizontalInput != 0 && verticalInput != 0)
        {
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                verticalInput = 0;
            }
            else
            {
                horizontalInput = 0;
            }
        }

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement = movement.normalized;

        transform.position += movement * speed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = projectilePoolReference.GetPooledObject();
            if(bullet != null)
            {
                bullet.transform.position = spawnBullet.transform.position;
                bullet.transform.rotation = spawnBullet.transform.rotation;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        rb.velocity = Vector3.zero;
        transform.position = respawnPoint.position;
    }
}