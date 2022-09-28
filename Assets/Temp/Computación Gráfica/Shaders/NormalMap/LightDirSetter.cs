using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class LightDirSetter : MonoBehaviour
{
    const string LIGHT_DIR_REFERENCE = "_LightDirectionWS";
    [SerializeField] private Material material;
    int lightDirNameId;

    void SetLightDir()
    {
        if (material == null) return;
        
        material.SetVector(lightDirNameId, -transform.forward);
    }

    private void Awake()
    {
        lightDirNameId = Shader.PropertyToID(LIGHT_DIR_REFERENCE);
    }
    private void Update()
    {
        SetLightDir();
    }

}
