float4x4 World;
float4x4 View;
float4x4 Projection;

// TODO: add effect parameters here.
Texture normalTexture;
Texture winterTexture;
float gameTime;

sampler normalTextureSampler = sampler_state
{
	texture = <normalTexture>;
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;
};

sampler winterTextureSampler = sampler_state
{
	texture = <winterTexture>;
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;
};

struct VertexShaderInput
{
    float4 Position : POSITION0;
	float2 textureCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
	float2 textureCoord : TEXCOORD0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;

    float4 worldPosition = mul(input.Position, World);
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);

    // TODO: add your vertex shader code here.
	output.textureCoord = input.textureCoord;

    return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
    // TODO: add your pixel shader code here.
	float4 output;
	float4 result1 = tex2D(normalTextureSampler, input.textureCoord);
	float4 result2 = tex2D(winterTextureSampler, input.textureCoord);
	//float clampedGameTime = clamp(gameTime, 0.0, 1.0);

	float transitionTime = abs(frac(gameTime) - 0.5); // Ajuste conforme necessário
    float clampedTransitionTime = clamp(transitionTime * 2.0, 0.0, 1.0);

	output = lerp(result2, result1, clampedTransitionTime);

    return output;
}

technique Technique1
{
    pass Pass1
    {
        // TODO: set renderstates here.

        VertexShader = compile vs_2_0 VertexShaderFunction();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
