#version 330 core

out vec4 outPutColor;

in vec3 ourColor;

void main()
{
  outPutColor  = vec4(ourColor, 1.0);
}