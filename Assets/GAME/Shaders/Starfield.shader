// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Starfield"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
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
			fixed filler;
		};

		void surf( Input input , inout SurfaceOutputStandard output )
		{
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=21
994;100;600;1039;426;475.5;1;True;False
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;True;Standard;Starfield;False;False;False;False;False;False;False;False;False;False;False;False;Back;On;LEqual;Opaque;0.5;True;True;0;False;Opaque;Geometry;0,0,0;0,0,0;0,0,0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0.0;0,0,0
ASEEND*/
//CHKSM=FF57DE311481729B1C56372DA158B05EBF8C69E4