#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
uniform float t;

sampler2D SpriteTextureSampler = sampler_state
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float2x2 Rot(float angle)
{
    float a = angle * (3.14 / 180.);
    return float2x2(cos(a), -sin(a), sin(a), cos(a));
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 col = tex2D(SpriteTextureSampler,input.TextureCoordinates) * input.Color;
    float2x2 rotation = Rot(45.);
    float2 rUV = mul(rotation, input.TextureCoordinates);
	
    if (rUV.y < fmod(t, 1.) * 2 + 0.1 && rUV.y > fmod(t, 1.) * 2 && col.a == 1.)
    {
        col.rgb = float3(1.,1.,1.);
    }
	
    return col; 
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};