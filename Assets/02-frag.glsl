#version 460 core

in vec4 v_Pos;
in vec3 v_Colour;

uniform sampler2D u_Texture;

void main()
{
    vec2 texCoords = vec2(v_Pos.x, v_Pos.z);
    gl_FragColor = texture(u_Texture, texCoords) * vec4(v_Colour, 1.0);
}
