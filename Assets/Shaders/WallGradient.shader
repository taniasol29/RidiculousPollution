Shader "Unlit/WallGradient"
{
    Properties
    {
        _ColorA("ColorA", Color) = (1.0, 1.0, 1.0, 1.0)
        _ColorB("ColorB", Color) = (1.0, 1.0, 1.0, 1.0)

        _ColorStart("Color Start", Range(0, 1)) = 0
        _ColorEnd("Color End", Range(0, 1)) = 1
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;

            float _ColorStart;
            float _ColorEnd;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                //float4 color : COLOR;
                float4 uv0 : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp(float a, float b, float v)
            {
                return (v - a) / (b - a);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Clamp
                float t = saturate(InverseLerp(_ColorStart, _ColorEnd, i.uv.y)); // with start/end sliders
                // frac = v - floor(v), some value minus floor of that value, values gonna repeat within 0 to 1 interval
                t = frac(t);
                float4 outColor = lerp(_ColorA, _ColorB, t);
                return outColor;
            }
            ENDCG
        }
    }
}
