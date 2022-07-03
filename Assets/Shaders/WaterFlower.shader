Shader "Unlit/WaterFlower"
{
    Properties
    {
        _ColorA("ColorA", Color) = (1.0, 1.0, 1.0, 1.0)
        _ColorB("ColorB", Color) = (1.0, 1.0, 1.0, 1.0)
        _ColorStart("Color Start", Range(0, 1)) = 0
        _ColorEnd("Color End", Range(0, 1)) = 1
        _WaveAmp("Wave Amplitude", Range(0, 1.0)) = 0.1
    }
        SubShader
    {
        Tags {
            "RenderType" = "Opaque" // tag to inform the render pipeline of what type this is
            //"Queue" = "Geometry" // changes the render order
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #define TAU 6.28318530718

            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;
            float _WaveAmp;

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
                float wave = cos((v.uv0.y - _Time.y * 0.1) * TAU * 5.0) * 0.5 + 0.5;
                float wave2 = cos((v.uv0.x - _Time.y * 0.1) * TAU * 5.0) * 0.5 + 0.5;
                v.vertex.y = wave * wave2 *_WaveAmp;
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
                //return float4(i.uv, 0, 1);
                
                float wave = cos((i.uv.y - _Time.y * 0.1) * TAU * 5.0) * 0.5 + 0.5;
                //wave *= 1 - i.uv.y;
                //wave *= i.uv.y;
                float4 gradient = lerp(_ColorA, _ColorB, wave);
                return gradient;
                //return wave;

            }
            ENDCG
        }
    }
}
