// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Video"
{
	Properties
	{
		_Smooth("Smooth", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_Float0("Float 0", Float) = 0
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf StandardSpecular alpha:premul keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_TextureSample0;
		};

		uniform sampler2D _TextureSample0;
		uniform float _Float0;
		uniform float _Smooth;

		void surf( Input input , inout SurfaceOutputStandardSpecular output )
		{
			float4 tex2DNode1 = tex2D( _TextureSample0,input.uv_TextureSample0);
			output.Albedo = tex2DNode1.xyz;
			float3 FLOATToFLOAT320=_Float0;
			output.Specular = FLOATToFLOAT320;
			output.Smoothness = _Smooth;
			output.Alpha = tex2DNode1.r;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
1167;744;1035;893;601.5;517.5;1;True;True
Node;AmplifyShaderEditor.SamplerNode;1;-445.5,-160.5;Property;_TextureSample0;Texture Sample 0;-1;None;True;0;False;white;Auto;False;Object;-1;0,0;1.0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-25,-176;True;StandardSpecular;Video;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Transparent;0.5;True;True;0;False;Transparent;Transparent;0,0,0;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
Node;AmplifyShaderEditor.RangedFloatNode;2;-272.5,-279.5;Property;_Float0;Float 0;-1;0;0;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-272.5,-361.5;Property;_Smooth;Smooth;-1;0;0;0
WireConnection;0;0;1;0
WireConnection;0;3;2;0
WireConnection;0;4;3;0
WireConnection;0;6;1;1
ASEEND*/
//CHKSM=418BFD9A4EEF5124F70351FC3036D21EBFAA0498