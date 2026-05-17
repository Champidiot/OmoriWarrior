using UnityEngine;

public class AllAttackScript : MonoBehaviour
{
    [SerializeField] private Transform Player;
    void Update()
    {

        gameObject.transform.position = new Vector3(Player.position.x, Player.position.y, Player.position.z);

    }
}
