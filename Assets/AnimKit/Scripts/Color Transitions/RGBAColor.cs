//----------------------------------------------------------------------------------------
// RGBAColor.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class represents a color in the RGBA color space. It provides methods to convert
//    between RGBA and Color color representations.
//
// Usage:
//    1. Create a new instance of RGBAColor using the constructor or the FromColor() method.
//    2. Access the red, green, blue, and alpha components of the color.
//    3. Convert the RGBA color to a Color using the ToColor() method.
//
// Public Variables:
//    - red: The red component of the color (0 to 1).
//    - green: The green component of the color (0 to 1).
//    - blue: The blue component of the color (0 to 1).
//    - alpha: The alpha component of the color (0 to 1).
//
// Public Methods:
//    - RGBAColor(float r, float g, float b, float a): Creates a new RGBAColor instance with
//       the specified RGBA values.
//    - ToColor(): Converts the RGBAColor to a Color.
//    - FromColor(Color color): Creates a new RGBAColor instance from a Color.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class RGBAColor
{
    public float red;
    public float green;
    public float blue;
    public float alpha;

    // Creates a new RGBAColor instance with the specified RGBA values
    public RGBAColor(float r, float g, float b, float a)
    {
        red = r;
        green = g;
        blue = b;
        alpha = a;
    }

    // Converts the RGBAColor to a Color
    public Color ToColor()
    {
        return new Color(red, green, blue, alpha);
    }

    // Creates a new RGBAColor instance from a Color
    public static RGBAColor FromColor(Color color)
    {
        return new RGBAColor(color.r, color.g, color.b, color.a);
    }
}