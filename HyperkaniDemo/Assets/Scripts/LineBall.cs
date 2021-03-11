using UnityEngine;

public class LineBall : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private int resolution = 20;
    [SerializeField] private float radius = 2f;


    private void Start()
    {
        Vector3[] points = GeneratePointsInCircle();
        SetPointsToLine(points);
    }

    private Vector3[] GeneratePointsInCircle()
    {
        Vector3[] points = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            float angle = 2f * Mathf.PI * (i / (float)resolution);
            points[i] = 
                transform.right * radius * Mathf.Sin(angle) +
                transform.up * radius * Mathf.Cos(angle);                
        }

        return points;
    }

    private void SetPointsToLine(Vector3[] points)
    {
        line.positionCount = resolution;
        line.loop = true;
        line.SetPositions(points);
    }
}
