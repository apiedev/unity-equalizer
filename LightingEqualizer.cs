using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEqualizer : MonoBehaviour {

    /* Public values that can be set in Unity */
	public AudioAnalyzer analyzer;
    public float intensity;
    public string colorShaderName;

    private Light curLight;
    private Material buildingLight;
	private float originalIntensity;
    

	// Use this for initialization
	private void Start () {

        if (analyzer == null)
            analyzer = GameObject.Find("Music").GetComponent<AudioAnalyzer>();

        if(gameObject.GetComponent<Light>() != null)
        {
            curLight = gameObject.GetComponent<Light>();

            originalIntensity = curLight.intensity;
        }
		    
        if (gameObject.GetComponent<SpriteRenderer>() != null)
            buildingLight = gameObject.GetComponent<SpriteRenderer>().material; 
	}
	
	// Update is called once per frame
	private void Update () {
        if(curLight != null)
		    curLight.intensity = (originalIntensity + (analyzer.RmsValue * 10)) * intensity;

        if(buildingLight != null)
            buildingLight.SetColor("_Color", new Color(buildingLight.GetColor("_Color").r, buildingLight.GetColor("_Color").g, buildingLight.GetColor("_Color").b, analyzer.RmsValue*5));
    }
}
