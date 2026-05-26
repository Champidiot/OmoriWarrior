using UnityEngine;

public class HPbar : MonoBehaviour
{

    [SerializeField] private PlayerScript PlayerScript;

    private float TailleInitial;

    private void Start()
    {
        TailleInitial = transform.localScale.x;

    }


    public void HPbarMiseAjour()
    {

        if (PlayerScript.HeroHp > PlayerScript.HeroMaxHp)
        {
           PlayerScript.HeroHp = PlayerScript.HeroMaxHp;
        }

        float ScaleX = (PlayerScript.HeroHp * TailleInitial) / PlayerScript.HeroMaxHp;

        transform.localScale = new Vector3(ScaleX , transform.localScale.y, transform.localScale.z);

        if (PlayerScript.HeroHp <= 0f)
        {
            transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
        }

    }
}
