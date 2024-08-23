using UnityEngine;

public class GrayScalePP : MonoBehaviour
{
    public Shader shader;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
    public void ActivateShader()
    {
        this.enabled = true;
    }
    public void DesactivateShader()
    {
        this.enabled = false;
    }
}
