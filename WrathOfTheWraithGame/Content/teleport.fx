#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
float t; 
float z;
float2 coords;


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
    z += t;
	float4 col = tex2D(SpriteTextureSampler,input.TextureCoordinates) * input.Color;
    float2 pUV = input.TextureCoordinates * 256.;
    float2 squareOrigin = float2(floor(pUV.x), floor(pUV.y));
    float radius = 3000;
	
    
    
     radius = min(1., 2. * sin(z * 20) * (1.5 - abs(sin(z * 20.))));
    col.rb += min(radius / length(squareOrigin - coords * 256), 0.4);
    col.g += min(.6 * radius / length(squareOrigin - coords * 256), 0.4);
    
    
        return col;
}

technique SpriteDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};