using System.IO.Enumeration;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient AmbeintColor;
    public Gradient DirectionalColor;
    public Gradient FogColor; 
}
