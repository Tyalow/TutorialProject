#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec3 aColor;
layout (location = 3) in vec3 aNormal;

out vec3 objectColor;
out vec2 texCoord;
out vec3 fragPos;
out vec3 normal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
   gl_Position = projection * view * model * vec4(aPos, 1.0);
   texCoord = aTexCoord;
   objectColor = aColor;
   normal = aNormal;
   fragPos = vec3(model * vec4(aPos, 1.0));
   
}