Shader "DynamicShadowProjector/FastShadowReceiver/Dynamic/Mipmapped Shadow For Lightmap Shadowmask" {
	Properties {
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Shadow Darkness", Range (0, 1)) = 1.0
		_ShadowMaskSelector ("Shadowmask Channel", Vector) = (1,0,0,0) 
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1" "IgnoreProjector"="True"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor Zero
			Offset [_OffsetSlope], [_Offset]

			HLSLPROGRAM
			#pragma vertex DSPProjectorVertMipmapForLightmap
			#pragma fragment DSPProjectorFragMipmapForLightmapShadowmask
			#pragma shader_feature_local _ FSR_PROJECTOR_FOR_LWRP
			#pragma multi_compile_local _ FSR_RECEIVER 
			#pragma multi_compile ___ UNITY_HDR_ON
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#pragma target 3.0
			#define DSP_USE_SHADOWMASK
			#define DSP_USE_MIPLEVEL
			#include "../UnityShaderVariablesForSRP.cginc"
			#include "../DSPProjector.cginc"
			#include "../DSPMipmappedShadow.cginc"
		// It is better to use UsePass to avoid copy-and-paste instead of creating a new Pass {},
		// but there is an issue that can occur when local shader keywords are used with UsePass.
		// UsePass "DynamicShadowProjector/Projector/Mipmapped Shadow For Lightmap Shadowmask/PASS"
			ENDHLSL
		}
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
