Shader "Unlit/WallWaves"
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
        Tags {
            "RenderType" = "Transparent" // tag to inform the render pipeline of what type this is
            "Queue" = "Transparent" // changes the render order
        }

        Pass
        {
            Cull Off // both back and front call

            ZWrite Off
            ZTest LEqual

            Blend One One // additive

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #define TAU 6.28318530718

            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
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
                float xOffset = cos(i.uv.y * TAU * 8.0) * 0.01;
                float t = cos((i.uv.x + xOffset - _Time.y * 0.1) * TAU * 5.0) * 0.5 + 0.5;
                t *= 1 - i.uv.x;

                float topBottomRemover = (abs(i.normal.x) < 0.999);
                float waves = t * topBottomRemover;
                float4 gradient = lerp(_ColorA, _ColorB, i.uv.x);
                
                return gradient * waves;
            }
            ENDCG
        }
    }
}
