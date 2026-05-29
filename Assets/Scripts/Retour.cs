using UnityEngine;
using UnityEngine.SceneManagement;

public class Retour : MonoBehaviour
{
    [SerializeField] private AudioSource over;

    [SerializeField] private AudioSource byebye;

    [SerializeField] private GameObject red;

    private void OnMouseEnter()
    {
        over.Play();
        red.SetActive(true);
    }

    private void OnMouseDown()
    {
        byebye.Play();
        SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
    }
}
