Shader "Custom/HyunShaderOutLineAdd" {
	Properties{
			_Color("Main Color", Color) = (.5,.5,.5,1)
			_MainTex("Base (RGB)", 2D) = "white" { }
			_ToonShade("ToonShader Cubemap(RGB)", CUBE) = "" { }
			_Brightness("Brightness = neutral", Float) = 2.0	
			_Shadow("ShadowValue",  Range(0.0, 1.0)) = 0.2
			_OutlineColor("Outline Color", Color) = (0,0,0,1)
			_Outline("Outline width", Range(.001, 0.03)) = .005	

	}

	CGINCLUDE
	#include "UnityCG.cginc"
	
		struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 pos : SV_POSITION;
		fixed4 color : COLOR;
	};

	uniform float _Outline;
	uniform float4 _OutlineColor;

	v2f vert(appdata v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
		float2 offset = TransformViewToProjection(norm.xy);
		o.pos.xy += offset * UNITY_Z_0_FAR_FROM_CLIPSPACE(o.pos.z) * _Outline;
	o.pos.xy += offset * o.pos.z * _Outline;
		o.color = _OutlineColor;
		return o;
	}
	ENDCG
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 250
		Lighting Off
		Fog{ Mode Off }
		UsePass "Custom/HyunShaderNomal/HYUNNOMAL"
		Pass{
		Name "OUTLINE"
		Tags{ "LightMode" = "Always" }
		Cull Front
		ZWrite On
		ColorMask RGBA
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile_fog
		fixed4 frag(v2f i) : SV_Target
		{
		return i.color;
		}
		ENDCG
		}
		}
		Fallback "Custom/HyunShaderNomal"
}

