using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour 
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField, Range(0, 24)] private float TimeOfDay;


    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24;
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f); 
        }
    }


    private void UpdateLighting(float timepercent)
    {
        RenderSettings.ambientLight = Preset.AmbeintColor.Evaluate(timepercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timepercent);

        if (DirectionalLight != null )
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timepercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timepercent * 360f) - 90f, 170f, 0)); 
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return; 

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;  
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>(); 
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return; 
                }
            }
        }
    }
}
