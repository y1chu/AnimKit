//----------------------------------------------------------------------------------------
// HSLAColor.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class represents a color in the HSLA color space. It provides methods to convert
//    between HSLA and RGBA color representations.
//
// Usage:
//    1. Create a new instance of HSLAColor using the constructor or the FromColor() method.
//    2. Access the hue, saturation, lightness, and alpha components of the color.
//    3. Convert the HSLA color to an RGBA color using the ToColor() method.
//
// Public Variables:
//    - hue: The hue component of the color (0 to 1).
//    - saturation: The saturation component of the color (0 to 1).
//    - lightness: The lightness component of the color (0 to 1).
//    - alpha: The alpha component of the color (0 to 1).
//
// Public Methods:
//    - HSLAColor(float h, float s, float l, float a): Creates a new HSLAColor instance with
//       the specified HSLA values.
//    - ToColor(): Converts the HSLAColor to an RGBA Color.
//    - FromColor(Color color): Creates a new HSLAColor instance from an RGBA Color.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class HSLAColor
{
    public float hue;
    public float saturation;
    public float lightness;
    public float alpha;

    // Creates a new HSLAColor instance with the specified HSLA values
    public HSLAColor(float h, float s, float l, float a)
    {
        hue = h;
        saturation = s;
        lightness = l;
        alpha = a;
    }

    // Converts the HSLAColor to an RGBA Color
    public Color ToColor()
    {
        return Color.HSVToRGB(hue, saturation, lightness, true).linear * alpha;
    }

    // Creates a new HSLAColor instance from an RGBA Color
    public static HSLAColor FromColor(Color color)
    {
        Color.RGBToHSV(color, out float h, out float s, out float v);
        return new HSLAColor(h, s, v, color.a);
    }
}
