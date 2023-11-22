using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform centroDelCarrusel;
    public float velocidadRotacion = 30f;
    public float tiempoVisible = 5f; // Tiempo en segundos para que cada grupo sea visible.
    public float retardoInicial = 2f; // Retardo inicial antes de que comience el movimiento.

    private Transform[] hijos;
    private int grupoActual = 0;
    private float tiempoUltimoCambio;
    private int objetosPorGrupo = 3;

    void Start()
    {
        // Obtén los hijos del objeto actual.
        hijos = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            hijos[i] = transform.GetChild(i);
            // Haz que todos los objetos estén inicialmente invisibles.
            hijos[i].gameObject.SetActive(false);
        }

        tiempoUltimoCambio = Time.time + retardoInicial;
    }

    void Update()
    {
        // Verifica si es hora de cambiar el grupo visible.
        if (Time.time - tiempoUltimoCambio >= tiempoVisible)
        {
            CambiarGrupoVisible();
        }

        // Rotar todas las imágenes alrededor del centro.
        foreach (Transform hijo in hijos)
        {
            hijo.RotateAround(centroDelCarrusel.position, Vector3.down, velocidadRotacion * Time.deltaTime);
        }
    }

    void CambiarGrupoVisible()
    {
        for (int i = 0; i < hijos.Length; i++)
        {
            int grupo = i / objetosPorGrupo;
            bool deberiaSerVisible = grupo == grupoActual;

            // Activa o desactiva el objeto según el grupo.
            hijos[i].gameObject.SetActive(deberiaSerVisible);
        }

        // Actualiza el tiempo del último cambio y avanza al siguiente grupo.
        tiempoUltimoCambio = Time.time;
        grupoActual = (grupoActual + 1) % (hijos.Length / objetosPorGrupo);
    }
}
