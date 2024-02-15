// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ClippedVertexColor" {
    SubShader {
    Pass {
        LOD 200
              
                 
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
  
        struct VertexInput {
            float4 v : POSITION;
            float4 color: COLOR;
        };
         
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float4 col : COLOR;
            float3 worldPos : TEXCOORD2;
        };
         
        float ClipAbove;
        float ClipBelow;

        VertexOutput vert(VertexInput v) {
         
            VertexOutput o;
            o.pos = UnityObjectToClipPos(v.v);
            o.col = v.color;
            float3 worldPos = mul(unity_ObjectToWorld, v.v).xyz;
            o.worldPos = worldPos;

            return o;
        }
         
        float4 frag(VertexOutput o) : COLOR {
            if (o.worldPos.y > ClipAbove) {
                discard;
            }
            if (o.worldPos.y < ClipBelow) {
                discard;
            }


            return o.col;
        }
 
        ENDCG
        } 
    }
 
}
