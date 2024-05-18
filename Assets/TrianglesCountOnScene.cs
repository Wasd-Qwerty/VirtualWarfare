using UnityEngine;

public class TrianglesCountOnScene : MonoBehaviour
{
    public int trianglesCount = 0;
    public int lastChange = 0;
    private int preTrianglesCount = 0;
    [SerializeField] private bool _naming;
    
    private void OnDrawGizmos()
    {
        MeshFilter[] meshFilters = FindObjectsOfType<MeshFilter>();

        trianglesCount = 0;

        foreach (var meshFilter in meshFilters)
        {
            Mesh mesh = meshFilter.sharedMesh;
            if (mesh != null && meshFilter.gameObject.activeSelf)
            {
                int[] triangles = mesh.triangles;
                if (_naming)
                {
                    meshFilter.gameObject.name += " " + (triangles.Length / 3);
                }
                trianglesCount += triangles.Length / 3;
            }
        }
        _naming = false;

        if (preTrianglesCount != trianglesCount)
        {
            lastChange = trianglesCount - preTrianglesCount;
        }
        preTrianglesCount = trianglesCount;
    }

}
