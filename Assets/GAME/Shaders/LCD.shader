// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "LCD"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_tex_screen("tex_screen", 2D) = "white" {}
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
			float2 uv_tex_screen;
		};

		uniform sampler2D _tex_screen;

		void surf( Input input , inout SurfaceOutputStandard output )
		{
			output.Albedo = tex2D( _tex_screen,input.uv_tex_screen).xyz;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
1459;92;768;1052;658.5;400.5;1;False;False
Node;AmplifyShaderEditor.SamplerNode;1;-243,-32.5;Property;_tex_screen;tex_screen;-1;Assets/GAME/Textures/tex_screen.png;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;135,-36;True;Standard;LCD;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Opaque;0.5;True;True;0;False;Opaque;Geometry;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
WireConnection;0;0;1;0
ASEEND*/
//CHKSM=007A0F9ACE40A18C65A677845E74A01197115316