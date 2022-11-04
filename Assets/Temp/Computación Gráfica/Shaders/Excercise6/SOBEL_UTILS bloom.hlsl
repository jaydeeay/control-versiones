#ifndef SOBEL_UTILS
#define SOBEL_UTILS

void BoxBlur_float(UnityTexture2D tex,UnitySamplerState ss,float2 uv,float2 offset,float2 texelSize,out float4 resul)
{
    float4 resul1;
    offset*=texelSize;
    resul =SAMPLE_TEXTURE2D(tex,ss,uv);
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(-1,1))*-1;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(0,1))*0;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(1,1))*1;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(-1,0))*-2;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(1,0))*2;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(-1,-1))*-1;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(0,-1))*0;
    resul+=SAMPLE_TEXTURE2D(tex,ss,uv+offset*float2(1,-1))*1;
}
#endif 