// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Crate"
{
	Properties
	{
		_tex_crate_g("tex_crate_g", 2D) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
		_tex_crate_s("tex_crate_s", 2D) = "white" {}
		_tex_crate_n("tex_crate_n", 2D) = "bump" {}
		_tex_crate_d("tex_crate_d", 2D) = "white" {}
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
			float2 uv_tex_crate_n;
			float2 uv_tex_crate_d;
			float2 uv_tex_crate_s;
			float2 uv_tex_crate_g;
		};

		uniform sampler2D _tex_crate_n;
		uniform sampler2D _tex_crate_d;
		uniform sampler2D _tex_crate_s;
		uniform sampler2D _tex_crate_g;

		void surf( Input input , inout SurfaceOutputStandard output )
		{
			output.Normal = UnpackNormal( tex2D( _tex_crate_n,input.uv_tex_crate_n) );
			output.Albedo = tex2D( _tex_crate_d,input.uv_tex_crate_d).xyz;
			output.Metallic = tex2D( _tex_crate_s,input.uv_tex_crate_s).x;
			output.Smoothness = tex2D( _tex_crate_g,input.uv_tex_crate_g).x;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
1353;92;825;1008;-548.2;1130.9;1;False;False
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;76,-47;True;Standard;Crate;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Opaque;0.5;True;True;0;False;Opaque;Geometry;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
Node;AmplifyShaderEditor.SamplerNode;2;-274,-151.5;Property;_tex_crate_d;tex_crate_d;-1;Assets/GAME/Textures/Crate/tex_crate_d.png;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.SamplerNode;3;-294,300.5;Property;_tex_crate_g;tex_crate_g;-1;Assets/GAME/Textures/Crate/tex_crate_g.png;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.SamplerNode;4;66,385.5;Property;_tex_crate_s;tex_crate_s;-1;Assets/GAME/Textures/Crate/tex_crate_s.png;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.SamplerNode;1;-326,78.5;Property;_tex_crate_n;tex_crate_n;-1;Assets/GAME/Textures/Crate/tex_crate_n.png;True;0;True;bump;Auto;True;Object;-1;0,0;1.0
WireConnection;0;0;2;0
WireConnection;0;1;1;0
WireConnection;0;3;4;0
WireConnection;0;4;3;0
ASEEND*/
//CHKSM=F762170AC91AD57F1649DB86EF66588DD8743ACC