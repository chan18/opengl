// This line creates a new instance, and wraps the instance in a using statement so it's automatically disposed once we've exited the block.
//using basic.Rectangle;
using basic.shaderGLSL;
using basic.textures;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

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

//using (uniformShaderWindow game = new uniformShaderWindow(800, 600, "LearnOpenTK"))
//{
//    game.Run();
//}

var nativeWindowSettings = new NativeWindowSettings()
{
    ClientSize = new Vector2i(800, 600),
    Title = "LearnOpenTK - Textures",
    // This is needed to run on macos
    Flags = ContextFlags.ForwardCompatible,
};

using (TextureWindow game = new TextureWindow(GameWindowSettings.Default, nativeWindowSettings))
{
    game.Run();
}

