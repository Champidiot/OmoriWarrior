using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float move_speed = 8f;

    public float HeroHp;

    public float HeroMaxHp = 50f;

    private Animator animator;





    void Start()
    {
        HeroHp = HeroMaxHp;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMouv();
    }





    private void PlayerMouv()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
            animator.SetBool("IsMooving", true);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
            animator.SetBool("IsMooving", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1f;
            animator.SetBool("IsMooving", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1f;
            animator.SetBool("IsMooving", true);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsMooving", false);
        }

        direction.Normalize();

        transform.position += direction * (move_speed * Time.deltaTime);
    }
}
