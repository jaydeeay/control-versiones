Shader "Example/LambertMultipleLightsCode"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Normal ("Normal Map"), 2D = "bump"{}
        _NormalStrength("Normal Strength", float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"            

            struct Attributes
            {
                float4 positionOS   : POSITION;       
                float2 texcoord     : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 texcoord     : TEXCOORD0;
            };            

            sampler2D _Maintex;
            float 4 _Maintex_ST;

            sampler2D _Normal;
            float 4 _Normal_ST;

            float _NormalStrength;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.texcoord = IN.texcoord;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {;
                half4 albedo = tex2D(_MainTex, IN.texcoord);
                return albedo;
            }
            ENDHLSL
        }
    }
}