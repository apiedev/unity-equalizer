using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEqualizer : MonoBehaviour {

    /* Public values that can be set in Unity */
    [Tooltip("Audio Analyzer should be attached to Audio Source and set here.")]
    public AudioAnalyzer analyzer;

    /* Intensity of the equalizing effect */
    public float intensity;

    /* Color component of shader to modify alpha channel */
    [Tooltip("Shader Settings -> Select Shader -> Properties: Usually named _Color")]
    public string colorShaderName;

    /* These should be attached to the same object as this script */
    private Light curLight;
    private Material objectLightSprite;
	private float originalIntensity;
    

	/* Called upon game start or object initialization */
	private void Awake () {

        /* If you don't automatically set an analyzer, it searches the scene for one */
        if (analyzer == null)
            analyzer = GameObject.FindObjectOfType<AudioAnalyzer>();

        /* If there is a light component attached, sets up vars required */
        if(gameObject.GetComponent<Light>() != null)
        {
            curLight = gameObject.GetComponent<Light>();
            originalIntensity = curLight.intensity;
        }
		    
        /* Attempts to grab the material of a sprite on this object */
        if (gameObject.GetComponent<SpriteRenderer>() != null)
            objectLightSprite = gameObject.GetComponent<SpriteRenderer>().material; 
	}
	
	/* Called once per frame by the Unity Engine */
	private void Update () {

        /* If there's a light, update its intensity with the music */
        if(curLight != null)
		    curLight.intensity = (originalIntensity + (analyzer.RmsValue * 10)) * intensity;

        /* If there's a light sprite, update its transparency with the music */
        if(objectLightSprite != null)
            objectLightSprite.SetColor("_Color", new Color(objectLightSprite.GetColor(colorShaderName).r, objectLightSprite.GetColor(colorShaderName).g, objectLightSprite.GetColor(colorShaderName).b, analyzer.RmsValue*intensity));
    }
}
