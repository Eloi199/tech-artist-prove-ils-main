
#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

void GML_float(float3 WorldPos, out float3 Vector, out float3 Colour, out half DistanceAtten, out half ShadowAtten) {
#if SHADERGRAPH_PREVIEW
    Vector = half3(0.5, 0.5, 0);
    Colour = 1;
    DistanceAtten = 1;
    ShadowAtten = 1;
#else
#if SHADOWS_SCREEN
    half4 clipPos = TransformWorldToHClip(WorldPos);
    half4 shadowCoord = ComputeScreenPos(clipPos);
#else
    half4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
#endif
    Light mainLight = GetMainLight(shadowCoord);
    Vector = mainLight.direction;
    Colour = mainLight.color;
    DistanceAtten = mainLight.distanceAttenuation;
    ShadowAtten = mainLight.shadowAttenuation;
#endif
}

void AddLights_float(float Smoothness, float3 WorldPosition, float3 WorldNormal, float3 WorldView,
    float MainDiffuse, float MainSpecular, float3 MainColour,
    out float Diffuse, out float Specular, out float3 Colour) {
    Diffuse = MainDiffuse;
    Specular = MainSpecular;
    Colour = MainColour * (MainDiffuse + MainSpecular);

#ifndef SHADERGRAPH_PREVIEW
    int pixelLightCount = GetAdditionalLightsCount();
    for (int i = 0; i < pixelLightCount; ++i) {
        Light light = GetAdditionalLight(i, WorldPosition);
        half NdotL = saturate(dot(WorldNormal, light.direction));
        half atten = light.distanceAttenuation * light.shadowAttenuation;
        half thisDiffuse = atten * NdotL;
        half thisSpecular = LightingSpecular(thisDiffuse, light.direction, WorldNormal, WorldView, 1, Smoothness);
        Diffuse += thisDiffuse;
        Specular += thisSpecular;
        Colour += light.color * (thisDiffuse + thisSpecular);
    }
#endif

    half total = Diffuse + Specular;
    // If no light touches this pixel, set the color to the main light's color
    Colour = total <= 0 ? MainColour : Colour / total;
}

#endif




























