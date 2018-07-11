Shader "Custom/HyunShaderNomal" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	//_Glossiness ("Smoothness", Range(0,1)) = 0.5
	//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf(Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
		//Properties{
		//	_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		//	_MainTex("Base (RGB)", 2D) = "white" {}
		//_Ramp("Toon Ramp (RGB)", 2D) = "gray" {}
		//}
		//
		//	SubShader{
		//	Tags{ "RenderType" = "Opaque" }
		//	LOD 200
		//
		//	CGPROGRAM
		//#pragma surface surf ToonRamp
		//
		//	sampler2D _Ramp;
		//
		//// custom lighting function that uses a texture ramp based
		//// on angle between light direction and normal
		//#pragma lighting ToonRamp exclude_path:prepass
		//inline half4 LightingToonRamp(SurfaceOutput s, half3 lightDir, half atten)
		//{
		//#ifndef USING_DIRECTIONAL_LIGHT
		//	lightDir = normalize(lightDir);
		//#endif
		//
		//	half d = dot(s.Normal, lightDir)*0.5 + 0.5;
		//	half3 ramp = tex2D(_Ramp, float2(d,d)).rgb;
		//
		//	half4 c;
		//	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
		//	c.a = 0;
		//	return c;
		//}
		//
		//
		//sampler2D _MainTex;
		//float4 _Color;
		//
		//struct Input {
		//	float2 uv_MainTex : TEXCOORD0;
		//};
		//
		//void surf(Input IN, inout SurfaceOutput o) {
		//	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		//	o.Albedo = c.rgb;
		//	o.Alpha = c.a;
		//}
		//ENDCG
		//
		//}
		//
		//	Fallback "Diffuse"
		//}
