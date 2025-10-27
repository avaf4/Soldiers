using UnityEngine;

public class Soldier2_Movement : MonoBehaviour
{

    public float RotationSpeed = 90f;
    public float speed = 4f;
    public GameObject AmmoPrefab;
    public float ammo_x_offset = 0f;
    public float ammo_y_offset = 0f;
    Animator animator;
    Vector2 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // set the reference to the animator
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // moving
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("moving", true);
            transform.Translate(speed * Vector2.right * Time.deltaTime);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        // shooting
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetBool("shooting", true);
            GameObject obj;

            obj = Instantiate(AmmoPrefab);

            // move the ammo to the soldier's position
            obj.transform.rotation = transform.rotation;
            obj.transform.position = transform.position + Vector3.right * ammo_x_offset + Vector3.up * ammo_y_offset;
        }
        else
        {
            animator.SetBool("shooting", false);
        }

        // steering
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, speed * RotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -speed * RotationSpeed * Time.deltaTime);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            print("OnCollisionEnter2D: " + collision.gameObject.name);
            transform.position = initialPosition;
            GameManager.Score1 += 20;
        }
    }
}
