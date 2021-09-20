# AestheticTerrain documentation

## Programmer's Documentation

### Architecture discussion

The program is designed in a very strange way to accommodate a few requirements.
Firstly, I wanted everything to be contained in a single window to spare the user the suffering
of having to deal with multiple windows. Secondly, I wanted to avoid having to write everything related to
3D graphics from the ground up on the CPU when we have perfectly good tools for the job, such as OpenGL.

The compromise I have chosen is that the program is running an invisible OpenTK `GameWindow` "next" to the main window,
which acts as the target for rendering the terrain. The program flow acts approximately like this: the user clicks the render button,
the background gets rendered(on the CPU), the terrain gets generated, both get sent to the GPU and rendered onto an invisible
window, the framebuffer is harvested into a `Bitmap` and then either displayed in the main window or saved to a file.

### Technologies used

I have used OpenTK (https://opentk.net/) for the various 3D Graphics related parts of the code.
The rest is stock .NET 5.0 and C#.

### Classes

The actual program architecture is fairly simple. The two most important classes are
`MainWindow` and `Renderer`.
The main reason why I split the generators(`TerrainGenerator` and `BackgroundGenerator`) from the Renderer was to avoid having
too many properties in a single class. Another reason was to enable myself to shorten the property names to
avoid the Enterprise Java-esque hellscape of 50 character variable(property, class etc.) names.

All the other classes are mostly various helpers or additional functionality functions that didn't necessarily
have to be in their own classes, but I have to decided to split the off to improve legibility of the code.
Mostly things like `RejectionSampler`, `PerlinNoise`, `Serializer`, `Utils`.

I hope that the code is fairly legible and mostly self-documenting, so I'm going to be brief in the class descriptions and mostly
describe their high-level functionality 

#### MainWindow

This is a standard WinForm class with a lot of components to accommodate all the options that the user is given to manipulate the
resulting image. While the program is running in GUI mode, it also controls the program flow through the component events.
It also holds the instances of `Renderer`, `TerrainGenerator` and `BackgroundGenerator` with updated settings for image generation.

#### Renderer

This class is a wrapper for most of the direct OpenTK functionality, its instance holds a `GameWindow` and other parameters
regarding OpenGL so that it doesn't have to be controlled directly from the main form.

#### TerrainGenerator

This class is very short, it is pretty much just a wrapper for a single function with a lot of parameters, which I didn't want to
store directly in the main form class or in the renderer class to avoid unnecessary clutter. Its main and only job is to generate a
terrain `Mesh`, which is then passed to the renderer to be displayed on the image.

#### BackgroundGenerator

This class is very similar to the class before it. It mostly serves as a wrapper for the function that generates the background
image that gets passed to the renderer.

#### Serializer

This is the wrapper for Reflection functionality, which I have used to serialize and deserialize the program without having to write
out everything by hand. The fortunate side-effect(I actually chose this by design) of this approach is that the resulting serialized
file is still pretty much legible.

#### OpenGL Wrapper Classes

This includes `Shader`, `Mesh`, `Texture` and `Camera`(well, not this one exactly, but the description fits as well).
These classes would truly show their worth in larger and more complicated application, but here, they're present mostly
so I can use certain parts of the OpenGL pipeline without having to write out all the calls directly and risking making
a dumb mistake that takes hours to find and fix.

#### PerlinNoise, RejectionSampler and Quadratic2D

These classes function as wrappers for certain mathematical functionality that I required(continuous good looking noise,
randomly sampling with a minimum distance and a 2D quadratic function).
They could've been in a single file called something like `ATMath` or something, but I have kept them
like this so that I can easily reference them in my future projects.

#### Utils

This class is an assortment of certain Extension methods and other functionality that didn't deserve its own file.