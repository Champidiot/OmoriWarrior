using UnityEngine;

public class balleRebond : MonoBehaviour
{
    [SerializeField] private GameObject balle;

    private float vitesseBalle = 20f;

    private float timerballe = 0f;

    private float NiveauAme = 0f;

    private float Cooldown;

    private void Update()
    {
        timerballe += Time.deltaTime;
    }

    private void GenererBalle()
    {
        if(timerballe >= Cooldown)
        {

        }
    }
}
