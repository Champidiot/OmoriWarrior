using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float move_speed = 8f;

    public float HeroHp = 50f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouv();

        Debug.Log(HeroHp);
    }





    private void PlayerMouv()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1f;
        }

        direction.Normalize();

        transform.position += direction * (move_speed * Time.deltaTime);
    }
}
