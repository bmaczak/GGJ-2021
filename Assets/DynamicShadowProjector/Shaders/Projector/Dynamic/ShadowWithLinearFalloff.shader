Shader "DynamicShadowProjector/Projector/Dynamic/Shadow With Linear Falloff" {
	Properties {
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Shadow Darkness", Range (0, 1)) = 1.0
		_Ambient ("Ambient", Range (0.01, 1)) = 0.3
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor Zero
			Offset [_OffsetSlope], [_Offset]

			HLSLPROGRAM
			#pragma vertex DSPProjectorVertLinearFalloff
			#pragma fragment DSPProjectorFrag
			#pragma shader_feature_local _ FSR_PROJECTOR_FOR_LWRP
			#pragma multi_compile_local _ FSR_RECEIVER 
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#define DSP_USE_AMBIENT
			#include "../DSPProjector.cginc"
		// It is better to use UsePass to avoid copy-and-paste instead of creating a new Pass {},
		// but there is an issue that can occur when local shader keywords are used with UsePass.
		// UsePass "DynamicShadowProjector/Projector/Shadow With Linear Falloff/PASS"
			ENDHLSL
		}
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
