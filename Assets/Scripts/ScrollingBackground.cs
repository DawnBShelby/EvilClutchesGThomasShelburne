using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // This code makes the background image scroll
    public float xSpeed;
    public float ySpeed;

    [SerializeField] private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(xSpeed * Time.deltaTime, ySpeed);
    }
}
