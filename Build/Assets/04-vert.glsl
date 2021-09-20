#version 460 core

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 normal;
layout(location = 2) in vec3 colour;
layout(location = 3) in vec2 texCoords;

out vec2 v_TexCoords;

void main()
{
    v_TexCoords = texCoords;
    gl_Position = position;
}
