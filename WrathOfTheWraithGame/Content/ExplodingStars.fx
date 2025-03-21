﻿#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
uniform float2 playerPos;
uniform float time; 

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

float4 MainPS(VertexShaderOutput input) : COLOR
{
	float4 col = tex2D(SpriteTextureSampler,input.TextureCoordinates) * input.Color;
    col.a = 1;
    float radius = 1.2;
    float2 pUV = input.TextureCoordinates * 256.;
    float2 coords = float2(floor(pUV.x), floor(pUV.y) );
    col.bg += 3. / length(playerPos*256. - coords);
    col.a -= 40. / length(playerPos * 256. - coords);
	
    return col;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};