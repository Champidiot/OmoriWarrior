using TMPro;
using UnityEngine;

public class TextDegat : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    private float vitesseMontee = 2f;
    private float tempsDeVie = 0.2f;

    public void Configurer(int pointsDeDegat)
    {
        text = GetComponent<TextMeshPro>();
        text.text = pointsDeDegat.ToString();
        text.fontSize = 7f + ((pointsDeDegat/10)*2);

        Destroy(gameObject, tempsDeVie);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * vitesseMontee * Time.deltaTime);
    }
}
