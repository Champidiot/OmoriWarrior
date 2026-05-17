using UnityEngine;

public class CarreChoix : MonoBehaviour
{

    public int AmeliorationDonne = 0;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Curseur;

    private void OnMouseDown()
    {

        ChoixFeunetre.SetActive(false);

        Curseur.SetActive(true);

        Time.timeScale = 1f;

    }
}
