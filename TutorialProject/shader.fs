#version 330 core
out vec4 FragColor;

in vec2 texCoord;
in vec3 objectColor;
in vec3 normal;
in vec3 fragPos;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixValue;
uniform vec3 lightColor;

void main()
{
    vec2 someVec = vec2(-texCoord.x, texCoord.y);
    FragColor = vec4(lightColor, 1.0) * (vec4(objectColor, 1.0) * mix(texture(texture1, texCoord), texture(texture2, someVec), mixValue));
}