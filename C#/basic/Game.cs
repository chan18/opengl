using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Basic;

public class Game : GameWindow
{

    // We define them in normalized device coordinates - NDC
    float[] vertices = {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
        0.5f, -0.5f, 0.0f, //Bottom-right vertex
        0.0f,  0.5f, 0.0f  //Top vertex
    };

    int VertexBufferObject;

    Shader shader;

    [Obsolete]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Game(int width, int height, string title) : base(GameWindowSettings.Default,
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
                                                        new NativeWindowSettings() { Size = (width, height), Title = title })
    {

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

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        //Code goes here

        VertexBufferObject = GL.GenBuffer();

        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        // GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        // GL.DeleteBuffer(VertexBufferObject);

        shader = new Shader("shaders/shader.vert", "shaders/shader.frag");
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        //Code goes here.

        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        GL.Viewport(0, 0, e.Width, e.Height);
    }

    protected override void OnUnload()
    {
        base.OnUnload();

        shader.Dispose();
    }
}
