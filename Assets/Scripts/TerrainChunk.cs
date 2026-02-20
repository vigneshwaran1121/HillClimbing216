using UnityEngine;
using UnityEngine.U2D;

public class TerrainChunk : MonoBehaviour

{
    [SerializeField] private SpriteShapeController spriteShape;
    [SerializeField] private int pointCount = 35;  // More points = smoother
    [SerializeField] private float xMultiplier = 3f;  // Wider spacing
    [SerializeField] private float yMultiplier = 3f;  // Taller hills
    [SerializeField] private float smoothness = 0.8f;
    [SerializeField] private float noiseScale = 0.02f;  // FIXED: Bigger hills
    [SerializeField] private float bottom = -20f;
    [SerializeField] private float seed = 123.45f;

    public void Generate(float worldStartX)
    {
        if (spriteShape == null) spriteShape = GetComponent<SpriteShapeController>();
        var spline = spriteShape.spline;
        spline.Clear();

        // Generate terrain points with OVERLAP for seamless connection
        for (int i = 0; i < pointCount; i++)
        {
            // FIXED: Proper world-space sampling for continuous terrain
            float sampleX = (worldStartX + i * xMultiplier) * noiseScale;
            float height = Mathf.PerlinNoise(sampleX, seed);
            height = Mathf.Lerp(0.1f, 0.9f, height);  // Bigger height range

            Vector3 pos = new Vector3(i * xMultiplier, height * yMultiplier);
            spline.InsertPointAt(i, pos);

            if (i > 0 && i < pointCount - 1)
            {
                spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spline.SetLeftTangent(i, Vector3.left * xMultiplier * smoothness);
                spline.SetRightTangent(i, Vector3.right * xMultiplier * smoothness);
            }
        }

        // FIXED: Proper shape closing (no splits)
        Vector3 lastPos = spline.GetPosition(pointCount - 1);
        spline.InsertPointAt(pointCount, new Vector3(lastPos.x, bottom));
        spline.InsertPointAt(pointCount + 1, new Vector3(0, bottom));  // Connects to next chunk

        spriteShape.BakeCollider();
        spriteShape.RefreshSpriteShape();
    }
}
