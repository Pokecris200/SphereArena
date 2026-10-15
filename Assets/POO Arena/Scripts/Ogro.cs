using UnityEngine;

public class Ogro : MonoBehaviour
{
    private string nombre = "Ogro";
    [SerializeField] private int vida = 10;
    [SerializeField] private float velocidad = 1f;

    private void Presentarse()
    {
        Debug.Log($"Hola, soy {nombre} y tengo {vida} puntos de vida.");
    }

    private void Mover()
    {
        Debug.Log($"{nombre} se mueve a una velocidad de {velocidad}.");
    }

    private void Start()
    {
        Presentarse();
        Mover();
    }
}
