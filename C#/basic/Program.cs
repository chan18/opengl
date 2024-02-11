// See https://aka.ms/new-console-template for more information
using Basic;

// main function

// Console.WriteLine("Hello, World!");



// This line creates a new instance, and wraps the instance in a using statement so it's automatically disposed once we've exited the block.
using (OpenGlWindow game = new OpenGlWindow(800, 600, "LearnOpenTK"))
{
    game.Run();
}
