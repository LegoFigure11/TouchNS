using TouchNS.Core.Enums;

namespace TouchNS.Core;

internal static class Keyboards
{
    public static string GetKeyboard(KeyboardType kt) => kt switch
    {
        KeyboardType.English_UK     => "1#2£3€4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=",
        KeyboardType.English_US     => "1!2[3]4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=",
        KeyboardType.French         => "1@2%3&4#5*6^7º8+9÷0=-_aAzZeErRtTyYuUiIoOpP'/qQsSdDfFgGhHjJkKlLmM;€wWxXcCvVbBnN,(.)!«?»:\"",
        KeyboardType.French_Canada  => "1#2[3]4$5%6&7*8(9)0_@-qQwWeErRtTyYuUiIoOpP'=aAsSdDfFgGhHjJkKlL;+:/zZxXcCvVbBnNmM,«.»!\"?\\",
        KeyboardType.German         => "1!2\"3@4€5%6&7/8(9)0=ß?qQwWeErRtTzZuUiIoOpPüÜaAsSdDfFgGhHjJkKlLöÖäÄyYxXcCvVbBnNmM,;.:-_+*",
        KeyboardType.Spanish_Spain  => "1¡2!3¿4?5(6)7$8€9&0=@@qQwWeErRtTyYuUiIoOpP\"%aAsSdDfFgGhHjJkKlLñÑ\\/zZxXcCvVbBnNmM,;.:-_ºª",
        KeyboardType.Spanish_LATAM  => "1¡2!3¿4?5(6)7$8º9ª0=@#qQwWeErRtTyYuUiIoOpP\"%aAsSdDfFgGhHjJkKlLñÑ\\/zZxXcCvVbBnNmM,;.:-_*&",
        KeyboardType.Italian        => "1!2\"3£4$5%6&7/8(9)0='?qQwWeErRtTyYuUiIoOpPº*aAsSdDfFgGhHjJkKlL@€#_zZxXcCvVbBnNmM,;.:[+]-",
        KeyboardType.Italian_QZERTY => "£1$2\"3'4(5-6€7@8#9&0)ºqQzZeErRtTyYYuUiIoOpP+=aAsSdDfFgGhHjJkKlLmM*%wWxXcCvVbBnN,?;.:/[!]-",
        KeyboardType.Netherlands    => "1!2@3#4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP=+aAsSdDfFgGhHjJkKlL;:'\"zZxXcCvVbBnNmM,<.>/?\\€",
        KeyboardType.Portugese      => "1!2\"3#4€5%6&7(8)9?0[=]qQwWeErRtTyYuUiIoOpPº@aAsSdDfFgGhHjJkKlLçÇª*zZxXcCvVbBnNmM,;.:-_+£",
        KeyboardType.Russian        => "1!2?3\"4:5;6(7)8-9_0@ъЪйЙцЦуУкКеЕнНгГшШщЩзЗхХфФыЫвВаАпПрРоОлЛдДжЖэЭяЯчЧсСмМиИтТьЬбБюЮёЁ.,",
        KeyboardType.Russian_Latin  => "1#2£3€4$5%6^7&8*9(0)-_qQwWeErRtTyYuUiIoOpP/@aAsSdDfFgGhHjJkKlL:;'\"zZxXcCvVbBnNmM,<.>?+!=",
        _ => throw new NotImplementedException()
    };
}
