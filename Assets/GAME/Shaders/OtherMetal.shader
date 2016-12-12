// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "OtherMetal"
{
	Properties
	{
		_Smoothness("Smoothness", Range( 0 , 1)) = 0
		[HideInInspector] __dirty( "", Int ) = 1
		_Diffuse("Diffuse", 2D) = "white" {}
		_Metalness("Metalness", Range( 0 , 1)) = 0
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_Diffuse;
		};

		uniform sampler2D _Diffuse;
		uniform float _Metalness;
		uniform float _Smoothness;

		void surf( Input input , inout SurfaceOutputStandard output )
		{
			output.Albedo = tex2D( _Diffuse,input.uv_Diffuse).xyz;
			output.Metallic = _Metalness;
			output.Smoothness = _Smoothness;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
994;100;600;1039;428;519.5;1;False;False
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;True;Standard;OtherMetal;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Opaque;0.5;True;True;0;False;Opaque;Geometry;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
Node;AmplifyShaderEditor.SamplerNode;1;-369,-83.5;Property;_Diffuse;Diffuse;-1;None;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.RangedFloatNode;2;-373,119.5;Property;_Metalness;Metalness;-1;0;0;1
Node;AmplifyShaderEditor.RangedFloatNode;3;-365,218.5;Property;_Smoothness;Smoothness;-1;0;0;1
WireConnection;0;0;1;0
WireConnection;0;3;2;0
WireConnection;0;4;3;0
ASEEND*/
//CHKSM=734213BC8CAA72299AC76355B6234C74CB5C2A46