namespace TouchNS.Core;

internal static class KeyboardCoordinates
{
    private readonly static List<(int x, int y)> Coordinates = new()
    {
        {(100, 359)}, {(192, 359)}, {(293, 359)}, {(406, 359)}, {(475, 359)}, {(597, 359)}, {(679, 359)}, {(772, 359)}, {(864, 359)}, {(964, 359)}, {(1052, 359)},
        {(103, 432)}, {(186, 432)}, {(290, 432)}, {(394, 432)}, {(483, 432)}, {(576, 432)}, {(684, 432)}, {(767, 432)}, {(873, 432)}, {(950, 432)}, {(1055, 432)},
        {( 98, 493)}, {(198, 493)}, {(283, 493)}, {(379, 493)}, {(490, 493)}, {(571, 493)}, {(673, 493)}, {(764, 493)}, {(870, 493)}, {(966, 493)}, {(1055, 493)},
        {(100, 555)}, {(188, 555)}, {(283, 555)}, {(379, 555)}, {(489, 555)}, {(589, 555)}, {(655, 555)}, {(767, 555)}, {(853, 555)}, {(957, 555)}, {(1056, 555)},
    };

    private readonly static (int x, int y) SHIFT = (195, 621);
    private readonly static (int x, int y) SPACE = (750, 621);

    public static (int x, int y) GetCoordinate(int i) => Coordinates[i];
    public static (int x, int y) Shift => SHIFT;
    public static (int x, int y) Space => SPACE;
}
