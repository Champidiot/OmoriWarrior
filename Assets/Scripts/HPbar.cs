using UnityEngine;

public class HPbar : MonoBehaviour
{

    [SerializeField] private PlayerScript PlayerScript;

    private float TailleInitial;

    private float PositionInitial;

    private void Start()
    {
        TailleInitial = transform.localScale.x;

        PositionInitial = transform.position.x;
    }


    public void HPbarMiseAjour()
    {
        float ScaleX = (PlayerScript.HeroHp * TailleInitial) / PlayerScript.HeroMaxHp;

        transform.localScale = new Vector3(ScaleX , transform.localScale.y, transform.localScale.z);

        if (PlayerScript.HeroHp <= 0f)
        {
            transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }

    }
}
