using UnityEngine;

public class Ammo_movement : MonoBehaviour
{
    public float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector2.right * Time.deltaTime);
        // every 3 seconds that have passed, self-destruct
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
