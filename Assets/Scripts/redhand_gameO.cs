using UnityEngine;

public class redhand_gameO : MonoBehaviour
{
    public static int QuelBouton = 0;

    [SerializeField] private Transform Trans;

    public static bool IsOptionActivate = false;
    void Update()
    {

        switch (QuelBouton)
        {

            default:

                Trans.position = new Vector3(100, 100, 0);
                break;

            case 1:
                Trans.position = new Vector3(-2.3f, -3.72f, -0.71f);
                break;

            case 2:
                Trans.position = new Vector3(0f, -3.72f, -0.71f);
                break;
        }

    }

    private void Start()
    {
        Time.timeScale = 1f;
    }
}
