Shader "Custom/FractalShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Scale ("Scale", Float) = 1.0
        _XOffset ("X Offset", Float) = 0.0
        _YOffset ("Y Offset", Float) = 0.0
        _Aspect ("Aspect", Float) = 1.0
        _MaxIter ("Max Iterations", Range(1, 1000)) = 100
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Scale;
            float _Aspect;
            float _XOffset;
            float _YOffset;
            int _MaxIter;
            
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float2 ComplexSquare(float2 z)
            {
                return float2(z.x * z.x - z.y * z.y, 2.0 * z.x * z.y);
            }

            int Mandelbrot(float2 c)
            {
                float2 z = float2(0.0, 0.0);
                int i = 0;
                for (i = 0; i < _MaxIter; i++)
                {
                    z = ComplexSquare(z) + c;
                    if (dot(z, z) > 4.0)
                    {
                        break;
                    }
                }
                return i;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                const float2 uv = i.uv;
                const float2 c = (uv - 0.5) * float2(_Scale * _Aspect, _Scale) + float2(_XOffset, _YOffset);
                const int iter = Mandelbrot(c);
                float value = (float)iter / (float)_MaxIter;
                return float4(log2(value + 1), pow(value, 2), pow(value, 2), 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
