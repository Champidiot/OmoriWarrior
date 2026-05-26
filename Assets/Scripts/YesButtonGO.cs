using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButtonGO : MonoBehaviour
{
    [SerializeField] private AudioSource Over;

    [SerializeField] private AudioSource Click;

    private float timer;

    private bool ClicTap = false;

    [SerializeField] private string Scene;

    [SerializeField] private int nmbBt;

    private void OnMouseEnter()
    {
        Over.Play();
        redhand_gameO.QuelBouton = nmbBt;
    }

    private void OnMouseDown()
    {
        Click.Play();
        ClicTap = true;
    }

    private void Update()
    {
        if (ClicTap)
        {
            timer += Time.deltaTime;
            if(timer>= 0.3)
            {
                ClicTap = false;
                timer = 0f;
                redhand_gameO.QuelBouton = 0;
                SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Single);
            }
        }
        Debug.Log(ClicTap);
        Debug.Log(timer);
        Debug.Log(redhand_gameO.QuelBouton);
    }

    private void Start()
    {
        ClicTap = false;
        timer = 0f;
        redhand_gameO.QuelBouton = 0;
    }
}
