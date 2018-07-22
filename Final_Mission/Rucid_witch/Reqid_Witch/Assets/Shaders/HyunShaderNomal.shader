
Shader "Custom/HyunShaderNomal"   {
	Properties{
		_Color("Main Color", Color) = (.5,.5,.5,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_ToonShade("ToonShader Cubemap(RGB)", CUBE) = "" { }
	_Brightness("Brightness = neutral", Float) = 2.0
_Shadow("ShadowValue",  Range(0.0, 1.0)) = 0.2
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 250
		ZWrite On
		Lighting Off
		Fog{ Mode Off }
		Pass{
		Name "HYUNNOMAL"
		Cull Off//프레임 드랍의 원인일 수도 있다.

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag    
#pragma fragmentoption ARB_precision_hint_fastest  //공부

#include "UnityCG.cginc"
#pragma glsl_no_auto_normalization //공부
#pragma multi_compile_fog //공부


		sampler2D _MainTex;
		float4 _MainTex_ST;
		float _Shadow;
		struct appdata {
		float4 vertex : POSITION;
		float2 texcoord : TEXCOORD0;
		float3 normal : NORMAL;
		};

	struct v2f {
		float4 pos : SV_POSITION;
		float2 texcoord : TEXCOORD0;
		float3 cubenormal : TEXCOORD1;
	};

	v2f vert(appdata v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		float3 n = mul(UNITY_MATRIX_IT_MV, normalize(float4(v.normal,0)));
		normalize(n);
		n = n +float3(_Shadow, _Shadow, _Shadow);
		o.cubenormal = n;
		o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
		return o;
	}
	samplerCUBE _ToonShade;
	fixed _Brightness;
	float4 _Color;

	fixed4 frag(v2f i) : COLOR
	{ 
	fixed4 cube = texCUBE(_ToonShade, i.cubenormal);
	fixed4 col  = tex2D(_MainTex, i.texcoord)*_Color;
	fixed4 c= fixed4(_Brightness * cube.rgb * col.rgb, col.a);
	return _Brightness*col*cube;
	}
		ENDCG
	}
	}

		Fallback "VertexLit"
}