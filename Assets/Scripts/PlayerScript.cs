using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float move_speed = 8f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouv();
    }





    private void PlayerMouv()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x -= 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.y -= 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.y += 1f;
        }

        direction.Normalize();

        transform.position += direction * (move_speed * Time.deltaTime);
    }
}
