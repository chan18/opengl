// This line creates a new instance, and wraps the instance in a using statement so it's automatically disposed once we've exited the block.
//using basic.Rectangle;
using basic.shaderGLSL;

//using (OpenGlWindowDrawTraiangle game = new OpenGlWindowDrawTraiangle(800, 600, "LearnOpenTK"))
//{
//    game.Run();
//}

//using (OpenGlWindowDrawRectangle game = new OpenGlWindowDrawRectangle(800, 600, "LearnOpenTK"))
//{
//    game.Run();
//}

//using (ShaderInandOuts game = new ShaderInandOuts(800, 600, "LearnOpenTK"))
//{
//    game.Run();
//}

//using (AttributeShaderWindow game = new AttributeShaderWindow(800, 600, "LearnOpenTK"))
//{
//    game.Run();
//}

using (uniformShaderWindow game = new uniformShaderWindow(800, 600, "LearnOpenTK"))
{
    game.Run();
}