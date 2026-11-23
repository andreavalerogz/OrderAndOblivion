using UnityEditor;
using UnityEngine;

public class S_BookRowGenerator : MonoBehaviour
{
    [SerializeField] private int rowNumber = 1;
    [SerializeField] private int quantity = 8;
    [SerializeField] private float marginOffset = 0.12f;

    [SerializeField] private float shelveMargin = 0.05f;
    [SerializeField] private Vector3 rowDirection = Vector3.right;
    [SerializeField] private GameObject emptyRow;

    [ContextMenu("Generar Fila")]
    public void GenerarFila()
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject newEmptyRow = Instantiate(emptyRow, transform);
            newEmptyRow.name = $"Book_Row{rowNumber}_Col{i + 1}";

            // Coordenadas estrictamente locales respecto al generador
            float distancia = shelveMargin + (i * marginOffset);
            newEmptyRow.transform.localPosition = rowDirection * distancia;
            newEmptyRow.transform.localRotation = Quaternion.identity;
            newEmptyRow.transform.localScale = emptyRow.transform.localScale;
        }
    }
}
