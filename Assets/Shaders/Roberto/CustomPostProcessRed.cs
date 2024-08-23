using UnityEngine;

[ExecuteInEditMode]
public class CustomPostProcessRed : MonoBehaviour
{
    public Material postProcessMaterial;

    private const string colorToFadePropertyName = "_ColorToFade";
    private const string fadeAmountPropertyName = "_FadeAmount";

    public Color colorToFade = Color.red;
    [Range(0f, 1f)]
    public float fadeAmount = 0f;
    private void Awake()
    {
        if (postProcessMaterial == null) enabled = false;
        else postProcessMaterial.mainTexture = postProcessMaterial.mainTexture;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, postProcessMaterial);
    }
    private void updateMaterialFadeAmount()
    {
        if (postProcessMaterial == null) return;
        postProcessMaterial.SetFloat(fadeAmountPropertyName, fadeAmount);
    }
    private void updateMaterialColorToFade()
    {
        if (postProcessMaterial == null) return;
        postProcessMaterial.SetColor(colorToFadePropertyName, colorToFade);
    }
    private void OnValidate()
    {
        updateMaterialColorToFade();
        updateMaterialFadeAmount();
    }
    public void setColorToFade(Color newValue)
    {
        colorToFade = newValue;
        updateMaterialColorToFade();
    }
    public void setFadeAmount(float newValue)
    {
        fadeAmount = Mathf.Clamp01(newValue);
        updateMaterialFadeAmount();
    }
    public void ActivateShader()
    {
        fadeAmount = 0.5f;
        OnValidate();
    }
    public void DesactivateShader()
    {
        fadeAmount = 0.0f;
        OnValidate();
    }
}
