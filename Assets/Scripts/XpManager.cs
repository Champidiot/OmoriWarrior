using UnityEngine;

public class XpManager : MonoBehaviour
{
    public float Niveau;

    public float XpNecessaire;

    public float XpObtenu;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Curseur;


    void Start()
    {
        Niveau = 1;

        XpNecessaire = Niveau * 5;
    }


    void Update()
    {
        IsLvlAtteint();

        Debug.Log(XpObtenu + "/" + XpNecessaire);
    }

    private void IsLvlAtteint()
    {
        if(XpObtenu>= XpNecessaire)
        {
            Niveau += 1;

            XpObtenu -= XpNecessaire;

            XpNecessaire = Niveau * 5;

            Time.timeScale = 0f;

            ChoixFeunetre.SetActive(true);

            Curseur.SetActive(false);




        }
    }
}
