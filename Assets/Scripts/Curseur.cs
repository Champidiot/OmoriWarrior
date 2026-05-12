using UnityEngine;

public class Curseur : MonoBehaviour
{

    public Transform player;
    public float radius = 2.0f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - player.position).normalized;
        transform.position = player.position + direction * radius;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}