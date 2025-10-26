using UnityEngine;

public class Soldier1Movement : MonoBehaviour
{
    enum SoldierState { Idle, Moving, Shooting};
    SoldierState state;
    public float RotationSpeed = 90f;
    public float speed = 4f;
    public GameObject AmmoPrefab;
    public float ammo_x_offset = 0f;
    public float ammo_y_offset = 0f;  
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        // set the reference to the animator
        animator = GetComponent<Animator>();
        state = SoldierState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
        // read the keyboard and/or joystick
            case SoldierState.Idle:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    state = SoldierState.Moving;
                }
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    state = SoldierState.Shooting;
                }
                break;
            // moving behavior
            case SoldierState.Moving:
                if (Input.GetKey(KeyCode.W))
                {
                    animator.SetBool("moving", true);
                    transform.Translate(speed * Vector2.right * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("moving", false);
                    state = SoldierState.Idle;
                }
                break;
            case SoldierState.Shooting:
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    animator.SetBool("shooting", true);
                    GameObject obj;

                    obj = Instantiate(AmmoPrefab);

                    // move the fireball to the dragon's position
                    obj.transform.position = transform.position + Vector3.right * ammo_x_offset + Vector3.up * ammo_y_offset;
                }
                else
                {
                    animator.SetBool("shooting", false);
                    state = SoldierState.Idle;
                }
                break;
            default:
                break;
        }


        // steering state machine
        switch (state)
        {
            case SoldierState.Idle: // landed
            case SoldierState.Moving: // flying
            case SoldierState.Shooting: // Shooting
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0f, 0f, speed * RotationSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0f, 0f, -speed * RotationSpeed * Time.deltaTime);
                }
                break;
        }

    }
}
