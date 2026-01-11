using TouchNS.Core.Enums;
using static TouchNS.Core.Keyboards;

namespace TouchNS.Core;

public static class KeyboardTools
{
    private static string Keyboard = GetKeyboard(KeyboardType.English_UK);
    public static void SetKeyboard(KeyboardType kt) => Keyboard = GetKeyboard(kt);

    private static bool CheckKeyExists(char k) => Keyboard.Contains(k);

    private static (int x, int y, bool shift) GetCoordinate(char k)
    {
        if (!CheckKeyExists(k)) throw new ArgumentException($"Character: {k} does not exist in the base keyboard for the specified layout!");
        var i = Keyboard.IndexOf(k);
        var index = i / 2;
        var needsCaps = i % 2 == 1;

        var (x, y) = KeyboardCoordinates.GetCoordinate(index);
        return (x, y, needsCaps);
    }

    public static List<(int, int)> GetTouchCoordinatesFromString(string text, bool initTouch = true)
    {
        List<(int x, int y)> inputs = [];

        bool isCaps = false;

        if (initTouch) inputs.Add((0, 0)); // 0, 0 will init touch mode while not touching a keyboard key

        foreach (char c in text)
        {
            if (c == ' ')
            {
                // Space is caps agnostic, so ignore caps handling
                inputs.Add(KeyboardCoordinates.Space);
            }
            else
            {
                var (x, y, shift) = GetCoordinate(c);

                var needsShift = shift;

                if (needsShift != isCaps)
                {
                    inputs.Add(KeyboardCoordinates.Shift);
                    if (!isCaps) inputs.Add(KeyboardCoordinates.Shift); // Press shift again set to caps lock if not already on caps
                    isCaps = !isCaps;
                }

                inputs.Add((x, y));
            }
        }

        return inputs;
    }

}
