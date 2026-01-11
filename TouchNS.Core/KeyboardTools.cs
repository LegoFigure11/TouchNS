using TouchNS.Core.Enums;
using static TouchNS.Core.Keyboards;

namespace TouchNS.Core;

public static class KeyboardTools
{
    private static KeyboardType _keyboardType = KeyboardType.English_UK;
    private static string[] _keyboard = GetKeyboard(KeyboardType.English_UK);
    public static void SetKeyboard(KeyboardType kt) => _keyboard = GetKeyboard(_keyboardType = kt);

    private static bool CheckKeyExists(char k) => _keyboard.Any(kbd => kbd.Contains(k));

    private static int GetContainingKeyboard(char k, int first)
    {
        // Check the current keyboard first, if it exists
        if (_keyboard.Length >= first - 1)
            if (_keyboard[first].Contains(k)) return first;
        
        var i = 0;
        for (; i < _keyboard.Length; i++)
            if (_keyboard[i].Contains(k)) break;

        return i;
    }

    private static (int x, int y, bool shift) GetCoordinate(char k, int idx)
    {
        if (!CheckKeyExists(k)) throw new ArgumentException($"Character: {k} does not exist in the specified keyboard set!");
        var i = _keyboard[idx].IndexOf(k);
        var index = i / 2;
        var needsCaps = i % 2 == 1;

        var (x, y) = KeyboardCoordinates.GetCoordinate(index);
        return (x, y, needsCaps);
    }

    public static List<(int, int)> GetTouchCoordinatesFromString(string text, bool initTouch = true)
    {
        List<(int x, int y)> inputs = [];

        var isCaps = false;
        var kbdIdx = 0;

        if (initTouch) inputs.Add((0, 0)); // 0, 0 will init touch mode while not touching a keyboard key

        foreach (var c in text)
        {
            if (c == ' ')
            {
                // Space is caps agnostic and available on all keyboards, so ignore caps handling
                inputs.Add(KeyboardCoordinates.Space);
            }
            else
            {
                var index = GetContainingKeyboard(c, kbdIdx);

                if (index != kbdIdx)
                {
                    kbdIdx = index;
                    inputs.Add(KeyboardCoordinates.GetLayout(kbdIdx, _keyboardType));
                    if (kbdIdx == 1) isCaps = false; // Keyboard 2 (Index 1) has shift disabled
                }

                var (x, y, shift) = GetCoordinate(c, kbdIdx);

                if (shift != isCaps)
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
