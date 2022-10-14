Shader "Example/ForceField"
{
    Properties
    {
        _MainTex("Main Texture",2D) = "white" {}
        _DistortionMap("Distortion Map", 2D) = "black" {}
        _DistortionAmount("Distortion Amount", float) = 0.0
        _DistortionVelX("Distortion Speed X", float) = 0.0
        _DistortionVelY("Distortion Speed Y", float) = 0.0
        
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "RenderPipeline" = "UniversalRenderPipeline"  "Queue" = "Transparent"}

        Pass
        {
            //Lerp = A * t + B * (1 - T)
            Blend SrcAlpha OneMinusSrcAlpha
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"            

            struct Attributes
            {
                float4 positionOS   : POSITION;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float4 screenUv     :TEXCOORD0;
            };           
            
            sampler2D _MainTex;
            sampler2D _CameraColorTexture;
            sampler2D _DistortionMap;
            float _DistortionAmount;
            float _DistortionVelX;
            float _DistortionVelY;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.screenUv = OUT.positionHCS;
                OUT.screenUv.y *= -1;
                return OUT;
            }
            
            half4 frag(Varyings IN) : SV_Target
            {
                IN.screenUv.xy /= IN.screenUv.w;
                IN.screenUv.xy = IN.screenUv.xy * 0.5 + 0.5;
                float2 distorion = tex2D(
                    _DistortionMap, 
                    IN.screenUv.xy + _Time.y * float2(_DistortionVelX,_DistortionVelY)).rg * 2.0 - 1.0;

                return tex2D(_CameraColorTexture, IN.screenUv.xy + distorion * _DistortionAmount);
            }
            ENDHLSL
        }
    }
}