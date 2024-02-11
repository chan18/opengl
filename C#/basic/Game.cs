using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Basic;

public class OpenGlWindow : GameWindow
{
    // We define them in normalized device coordinates - NDC
    private readonly float[] vertices = {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
        0.5f, -0.5f, 0.0f, //Bottom-right vertex
        0.0f,  0.5f, 0.0f  //Top vertex
    };
    private int VertexBufferObject;
    private int VertexArrayObject;
    private Shader shader;

    [Obsolete]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public OpenGlWindow(int width, int height, string title) : base(GameWindowSettings.Default,
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
        VertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        VertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(VertexArrayObject);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);


        shader = new Shader("shaders/shader.vert", "shaders/shader.frag");
        shader.Use();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        // clear screen.
        GL.Clear(ClearBufferMask.ColorBufferBit);

        //Code goes here.
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        // double buffer -  OpenGL context
        SwapBuffers();
    }



    // It's really simple to detect key presses! 
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        //Get the state of the keyboard this frame
        // 'KeyboardState' is a property of GameWindow
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
        GL.DeleteBuffer(VertexBufferObject);
        GL.DeleteVertexArray(VertexArrayObject);

        GL.DeleteProgram(shader.Handle);

        shader.Dispose();
    }
}
