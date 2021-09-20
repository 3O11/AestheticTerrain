#version 460 core

layout(location = 0) in vec4 position;
layout(location = 1) in vec4 normal;
layout(location = 2) in vec3 colour;
layout(location = 3) in vec2 texCoords;

out vec4 v_Pos;
out vec3 v_Colour;

uniform mat4 u_Projection;
uniform mat4 u_View;
uniform mat4 u_Model;

void main()
{
    gl_Position = u_Projection * u_View * u_Model * position;
    v_Pos = position;
    v_Colour = colour;
}
