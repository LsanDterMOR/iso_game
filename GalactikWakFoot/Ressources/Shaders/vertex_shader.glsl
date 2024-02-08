#version 330 core

layout(location = 0) in vec3 vPosition;

uniform mat4 transformation;

void main() {
	gl_Position = transformation * vec4(vPosition, 1);
}