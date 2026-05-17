using TMPro;
using UnityEngine;

public class HPtext : MonoBehaviour
{
    [SerializeField] private PlayerScript PlayerScript;

    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        text.text = PlayerScript.HeroHp + "/" + PlayerScript.HeroMaxHp;
    }

    public void HPmiseAjour()
    {
        text.text = PlayerScript.HeroHp + "/" + PlayerScript.HeroMaxHp;
    }
}
