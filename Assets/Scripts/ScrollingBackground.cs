using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // This code makes the background image scroll
    public float speed;

    [SerializeField] private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
