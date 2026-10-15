using UnityEngine;

public class Heroe : MonoBehaviour
{
    private string nombre = "Heroe";
    [SerializeField] private int vida = 3;
    [SerializeField] private float velocidad = 5f;

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
