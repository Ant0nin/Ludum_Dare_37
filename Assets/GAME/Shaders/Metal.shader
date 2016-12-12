// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Metal"
{
	Properties
	{
		_Smoothmap("Smoothmap", 2D) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
		_Diffuse("Diffuse", 2D) = "white" {}
		_Metalmap("Metalmap", 2D) = "white" {}
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
			float2 uv_Metalmap;
			float2 uv_Smoothmap;
		};

		uniform sampler2D _Diffuse;
		uniform sampler2D _Metalmap;
		uniform sampler2D _Smoothmap;

		void surf( Input input , inout SurfaceOutputStandard output )
		{
			output.Albedo = tex2D( _Diffuse,input.uv_Diffuse).xyz;
			output.Metallic = tex2D( _Metalmap,input.uv_Metalmap).x;
			output.Smoothness = tex2D( _Smoothmap,input.uv_Smoothmap).x;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
994;100;600;1039;321.5;633;1;False;False
Node;AmplifyShaderEditor.RangedFloatNode;3;-249.5,171;Property;_Smooth;Smooth;-1;0;0;1
Node;AmplifyShaderEditor.SamplerNode;1;-305.5,-219;Property;_Diffuse;Diffuse;-1;Assets/GAME/Textures/Metal1/tex_metal_d.png;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;67,-187;True;Standard;Metal;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Opaque;0.5;True;True;0;False;Opaque;Geometry;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
Node;AmplifyShaderEditor.SamplerNode;2;-314.5,-24;Property;_Metalmap;Metalmap;-1;None;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.SamplerNode;4;-315.5,-412;Property;_Smoothmap;Smoothmap;-1;None;True;0;False;white;Auto;False;Object;-1;0,0;1.0
WireConnection;0;0;1;0
WireConnection;0;3;2;0
WireConnection;0;4;4;0
ASEEND*/
//CHKSM=99EB720C37C512EEF67E9ADCB5DC7C8FBF7AEB95