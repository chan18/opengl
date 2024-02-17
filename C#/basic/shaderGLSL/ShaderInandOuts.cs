using basic.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;

namespace basic.shaderGLSL;

internal class ShaderInandOuts : GameWindow
{
    private readonly float[] _vertices =
    {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
            0.5f, -0.5f, 0.0f, // Bottom-right vertex
            0.0f,  0.5f, 0.0f  // Top vertex
    };


    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private Shader _shader;


    [Obsolete]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ShaderInandOuts(int width, int height, string title) : base(GameWindowSettings.Default,
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                                                        new NativeWindowSettings() { Size = (width, height), Title = title })
    {

    }

    protected override void OnLoad()
    {
        base.OnLoad();

        // color of the window
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        _vertexBufferObject = GL.GenBuffer();

        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        // Vertex attributes are the data we send as input into the vertex shader from the main program.
        // So here we're checking to see how many vertex attributes our hardware can handle.
        // OpenGL at minimum supports 16 vertex attributes. This only needs to be called 
        // when your intensive attribute work and need to know exactly how many are available to you.
        GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
        Debug.WriteLine($"Maximum number of vertex attributes supported: {maxAttributeCount}");

        // in's and out's varaiable shaders
        _shader = new Shader("shaderGLSL/shaders/shader.vert", "shaderGLSL/shaders/shader.frag");
        _shader.Use();

        // uniform shaders

        // attribute shaders.
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        // clear screen.
        GL.Clear(ClearBufferMask.ColorBufferBit);

       // _shader.Use();

        GL.BindVertexArray(_vertexArrayObject);

        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        // double buffer -  OpenGL context
        SwapBuffers();
    }

    // It's really simple to detect key presses! 
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        //Get the state of the keyboard this frame
        // KeyboardState' is a property of GameWindow
        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        GL.Viewport(0, 0, e.Width, e.Height);
    }

    protected override void OnUnload()
    {
        base.OnUnload();

        // Unbind all the resources by binding the targets to 0/null.
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);
        GL.UseProgram(0);

        // Delete all the resources.
        GL.DeleteBuffer(_vertexBufferObject);
        GL.DeleteVertexArray(_vertexArrayObject);

        GL.DeleteProgram(_shader.Handle);

        _shader.Dispose();
    }        
}