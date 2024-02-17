#version 330 core

// the position variable has attribute position 0
layout (location = 0) in vec3 aPosition;

// specify a color output to the fragment shader
out vec4 vertexColor;

void main()
{
	// see how we directly give a vec3 to vec4's constructor
	gl_Position = vec4(aPosition, 1.0);

	// set the output variable to a dark red color
	vertexColor = vec4(0.5, 0.0, 0.0, 1.0);
}