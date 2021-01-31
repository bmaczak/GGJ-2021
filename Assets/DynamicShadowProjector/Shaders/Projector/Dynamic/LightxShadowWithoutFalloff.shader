Shader "DynamicShadowProjector/Projector/Dynamic/Light x Shadow Without Falloff" {
	Properties {
		[NoScaleOffset] _LightTex ("Light Cookie", 2D) = "gray" {}
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Light Intensity", Range (0, 1)) = 1.0
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor One
			Offset [_OffsetSlope], [_Offset]

			HLSLPROGRAM
			#pragma vertex DSPProjectorVertLightNoFalloff
			#pragma fragment DSPProjectorFragLightWithShadow
			#pragma shader_feature_local _ FSR_PROJECTOR_FOR_LWRP
			#pragma multi_compile_local _ FSR_RECEIVER 
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#include "../DSPProjector.cginc"
		// It is better to use UsePass to avoid copy-and-paste instead of creating a new Pass {},
		// but there is an issue that can occur when local shader keywords are used with UsePass.
		// UsePass "DynamicShadowProjector/Projector/Light x Shadow Without Falloff/PASS"
			ENDHLSL
		}
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
