#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 texCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixValue;

void main()
{
    vec2 someVec = vec2(-texCoord.x, texCoord.y);
    FragColor = vec4(ourColor, 1.0) * mix(texture(texture1, texCoord), texture(texture2, someVec), mixValue);
}