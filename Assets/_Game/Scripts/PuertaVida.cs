using UnityEngine;

public class PuertaVida : MonoBehaviour
{
    [Header("Vida de la puerta")]
    public float vidaMaxima = 100f;

    private float vidaActual;

    [Header("Daño por zombies")]
    [SerializeField] private float distanciaDeteccion = 1.5f;
    [SerializeField] private int zombiesNecesarios = 2;
    [SerializeField] private float danoPorSegundo = 10f;

    [SerializeField] private LayerMask zombieLayer;

    private int ContarZombiesCerca()
    {
        Collider2D[] zombies = Physics2D.OverlapCircleAll(
            transform.position,
            distanciaDeteccion,
            zombieLayer
        );

        return zombies.Length;
    }

    void Update()
    {
        int cantidadZombies = ContarZombiesCerca();

        if (cantidadZombies >= zombiesNecesarios)
        {
            RecibirDanio(danoPorSegundo * Time.deltaTime);
        }
    }

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;

        Debug.Log("La puerta recibió " + cantidad + " de daño. Vida restante: " + vidaActual);

        if (vidaActual <= 0)
        {
            DestruirPuerta();
        }
    }

    private void DestruirPuerta()
    {
        Debug.Log("¡La puerta fue destruida!");

        Destroy(gameObject);
    }
}