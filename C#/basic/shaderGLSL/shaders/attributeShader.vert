#version 330 core

// the position variable has attributes position 0
layout(location = 0) in vec3 aPosition;

// this is where the color values we assigned in the main program goes to
layout(location = 1) in vec3 aColor;

out vec3 ourColor;

void main(void)
{
	gl_Position = vec4(aPosition, 1.0);

	ourColor = aColor;
}