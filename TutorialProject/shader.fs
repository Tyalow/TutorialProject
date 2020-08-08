#version 330 core
out vec4 FragColor;

in vec2 texCoord;
in vec3 objectColor;
in vec3 normal;
in vec3 fragPos;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixValue;

uniform float ambientLightStrength;
uniform float specularLightStrength;

uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 viewPos;

void main()
{
    vec3 norm = normalize(normal);
    vec3 lightDirection = normalize(lightPos - fragPos);
    float diff = max(dot(norm, lightDirection), 0.0);
    vec3 diffuse = diff * lightColor;

    vec3 ambient = ambientLightStrength * lightColor;

    vec3 viewDirection = normalize(viewPos - fragPos);
    vec3 reflectDirection = reflect(-lightDirection, norm);
    float spec = pow(max(dot(viewDirection, reflectDirection), 0.0), 32);
    vec3 specular = specularLightStrength * spec * lightColor;

    vec3 lightSum = ambient + diffuse + specular;

    vec2 someVec = vec2(-texCoord.x, texCoord.y);

    FragColor = vec4(lightSum, 1.0) * (vec4(objectColor, 1.0) * mix(texture(texture1, texCoord), texture(texture2, someVec), mixValue));
}