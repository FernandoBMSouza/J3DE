float4x4 World;
float4x4 View;
float4x4 Projection;

// TODO: add effect parameters here.
Texture colorTexture;
sampler colorTextureSampler = sampler_state
{
	texture = <colorTexture>;
	magfilter = POINT;
	minfilter = POINT;
	mipfilter = POINT;
};

struct VertexShaderInput
{
    float4 Position : POSITION0;

    // TODO: add input channels such as texture
    // coordinates and vertex colors here.

	float2 textureCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;

    // TODO: add vertex shader outputs such as colors and texture
    // coordinates here. These values will automatically be interpolated
    // over the triangle, and provided as input to your pixel shader.

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
	output = tex2D(colorTextureSampler, input.textureCoord);

	// Cores Invertidas
	// output = 1 - tex2D(colorTextureSampler, input.textureCoord);

	// EMBACADO
	// output += tex2D(colorTextureSampler, input.textureCoord + (0.01));
	// output += tex2D(colorTextureSampler, input.textureCoord - (0.01));
	// output /= 3;

	// GRAYSCALE
	// return dot(output, float3(0.3, 0.59, 0.11));

	// VERMELHO
    // return float4(1, 0, 0, 1);

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
