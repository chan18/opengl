using basic.common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace basic.Rectangle;

public class OpenGlWindowDrawRectangle : GameWindow
{
    private readonly float[] _rectangleVertices = [
         0.5f,  0.5f, 0.0f, // top right
         0.5f, -0.5f, 0.0f, // bottom right
        -0.5f, -0.5f, 0.0f, // bottom left
        -0.5f,  0.5f, 0.0f // top left
    ];

    // EBO
    // note that we start from zero.
    private readonly uint[] _rectangleIndices =
    {
        0, 1, 3, // first triangle
        1, 2, 3 // second triangle.
    };

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private int _elementBufferObject;
    private Shader _shader;


    [Obsolete]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public OpenGlWindowDrawRectangle(int width, int height, string title) : base(GameWindowSettings.Default,
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                                                        new NativeWindowSettings() { Size = (width, height), Title = title })
    {

    }

    protected override void OnLoad()
    {
        base.OnLoad();

        // color of the window
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        //Code goes here
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _rectangleVertices.Length * sizeof(float), _rectangleVertices,
            BufferUsageHint.StaticDraw);

        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);


        // shader.GetAttribLocation("aPosition"); //  to skip the layout(location=0)
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _rectangleIndices.Length * sizeof(uint), _rectangleIndices,
            BufferUsageHint.StaticDraw);


        _shader = new Shader("Rectangle/shaders/shader.vert", "Rectangle/shaders/shader.frag");
        _shader.Use();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        // clear screen.
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        //Code goes here.
        //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        GL.DrawElements(PrimitiveType.Triangles, _rectangleIndices.Length, DrawElementsType.UnsignedInt, 0);

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

        GL.DeleteBuffer(_elementBufferObject);

        GL.DeleteProgram(_shader.Handle);

        _shader.Dispose();
    }        
}
